using AqarPlatform.Application.DTOs.Auth;
using AqarPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AqarPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await authService.LoginAsync(loginDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await authService.RegisterAsync(registerDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDto registerDto)
        {
            var result = await authService.RegisterAdminAsync(registerDto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
