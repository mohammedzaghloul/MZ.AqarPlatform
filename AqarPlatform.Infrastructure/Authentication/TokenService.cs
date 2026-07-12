using AqarPlatform.Application.Interfaces;
using AqarPlatform.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AqarPlatform.Infrastructure.Jwt
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
     

        public TokenService(IConfiguration configuration)
        {
            _config = configuration;
        }
        public ResponseToken CreateToken(CreateTokenFromate createTokenFromate)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,createTokenFromate.UserName),
                new Claim(ClaimTypes.Name,createTokenFromate.UserName),
                new Claim(ClaimTypes.Email,createTokenFromate.Email),
            };
            foreach (var role in createTokenFromate.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var issuer = _config["Jwt:ValidIssuer"] ?? _config["Jwt:Issuer"] ?? "";
            var audience = _config["Jwt:ValidAudience"] ?? _config["Jwt:Audience"] ?? "";

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Set expiration explicitly
                SigningCredentials = creds,
                Issuer = issuer,
                Audience = audience,
                TokenType = "JWT",
                IncludeKeyIdInHeader = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokens = tokenHandler.WriteToken(token);
            return new ResponseToken
            {
                Token = tokens,
                Expiration = tokenDescriptor.Expires ?? DateTime.UtcNow,
            };
        }

    }
    
}
