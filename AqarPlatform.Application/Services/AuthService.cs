using AqarPlatform.Application.DTOs.Auth;
using AqarPlatform.Application.Interfaces;
using AqarPlatform.Domain.Entities;
using AqarPlatform.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Security.Cryptography;

namespace AqarPlatform.Application.Services
{
    public class AuthService :IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthService(UserManager<ApplicationUser> userManager,
                           RoleManager<IdentityRole<Guid>> roleManager,
                           SignInManager<ApplicationUser> signInManager,
                           ITokenService tokenService,
                           IUnitOfWork unitOfWork,
                           IConfiguration configuration,IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
            this.mapper = mapper;
        }
        public async Task<Response<AuthResponseDto>> LoginAsync(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Invalid request"
                    };
                }

                var user = await userManager.FindByEmailAsync(loginDto.Email);

                if (user == null)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = $"Email {loginDto.Email} not found"
                    };
                }


                var isPasswordValid = await userManager.CheckPasswordAsync( user, loginDto.Password);


                if (!isPasswordValid)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Email or password invalid"
                    };
                }


                var roles = await userManager.GetRolesAsync(user);


                var token = tokenService.CreateToken(new CreateTokenFromate
                {
                    UserId = user.Id,
                    Email = user.Email!,
                    UserName = user.UserName!
                });

                var refreshToken = GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); 
                await userManager.UpdateAsync(user);

               
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,    
                    Secure = true,       
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                };

    
                return new Response<AuthResponseDto>
                {
                    Success = true,
                    Message = "Login successfully",
                    Data = new AuthResponseDto
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Token = token.Token,       
                        Expiration = token.Expiration
                        
                    }
                };

            }
            catch (Exception ex)
            {
                return new Response<AuthResponseDto>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
      

        private string  GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
      

        public async Task<Response<AuthResponseDto>> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                if (registerDto == null)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Request data cannot be null."
                    };
                }

                var user = mapper.Map<ApplicationUser>(registerDto);

                var result = await userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Registration failed.",
                        Errors = result.Errors
                            .Select(e => e.Description)
                            .ToList()
                    };
                }

                string role = registerDto.AccountType switch
                {
                    AccountType.User => "User",
                    AccountType.Owner => "Owner",

                    _ => throw new Exception("Invalid account type.")
                };

                var roleResult = await userManager.AddToRoleAsync(user, role);

                if (!roleResult.Succeeded)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Failed to assign role.",
                        Errors = roleResult.Errors
                            .Select(e => e.Description)
                            .ToList()
                    };
                }

                var token = tokenService.CreateToken(new CreateTokenFromate
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Roles = new List<string> { role }
                });
                var refreshToken = GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await userManager.UpdateAsync(user);


                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                };
                return new Response<AuthResponseDto>
                {
                    Success = true,
                    Message = "Registration completed successfully.",
                    Data = new AuthResponseDto
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Roles = new List<string> { role },
                        Token = token.Token,
                        Expiration = token.Expiration.AddDays(3),
                        RefreshToken = refreshToken,


                    }


                };
            }
            catch (Exception ex)
            {
                return new Response<AuthResponseDto>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string>
            {
                ex.InnerException?.Message ?? string.Empty
            }
                };
            }
        }
       // لازم يبقي ف admin عشان تشتغل 
        public async Task<Response<AuthResponseDto>> RegisterAdminAsync(RegisterDto registerDto)
        {
            try
            {
                if (registerDto == null)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Request data cannot be null."
                    };
                }

                var user = mapper.Map<ApplicationUser>(registerDto);

                var result = await userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                {
                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Registration failed.",
                        Errors = result.Errors
                            .Select(e => e.Description)
                            .ToList()
                    };
                }

                var roleResult = await userManager.AddToRoleAsync(user, "Admin");

                if (!roleResult.Succeeded)
                {
                    await userManager.DeleteAsync(user);

                    return new Response<AuthResponseDto>
                    {
                        Success = false,
                        Message = "Failed to assign Admin role.",
                        Errors = roleResult.Errors
                            .Select(e => e.Description)
                            .ToList()
                    };
                }

                var token = tokenService.CreateToken(new CreateTokenFromate
                {
                    UserId = user.Id,
                    UserName = user.UserName!,
                    Email = user.Email!,
                    Roles = new List<string> { "Admin" }
                });

                var refreshToken = GenerateRefreshToken();

                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);

                await userManager.UpdateAsync(user);

                return new Response<AuthResponseDto>
                {
                    Success = true,
                    Message = "Admin registered successfully.",
                    Data = new AuthResponseDto
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Token = token.Token,
                        RefreshToken = refreshToken,
                        Expiration = token.Expiration,
                        Roles = new List<string> { "Admin" }
                    }
                };
            }
            catch (Exception ex)
            {
                return new Response<AuthResponseDto>
                {
                    Success = false,
                    Message = ex.Message,
                    Errors = new List<string>
            {
                ex.InnerException?.Message ?? string.Empty
            }
                };
            }
        }

    }
}
