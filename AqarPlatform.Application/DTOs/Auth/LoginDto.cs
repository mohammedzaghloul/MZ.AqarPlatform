using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.DTOs.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
