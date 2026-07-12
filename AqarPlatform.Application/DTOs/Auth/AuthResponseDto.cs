using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.DTOs.Auth
{
    public class AuthResponseDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Token { get; set; } = null!;

        public string RefreshToken { get; set; } = null!;

        public DateTime Expiration { get; set; }
        public List<string> Roles {  get; set; }
    }
}
