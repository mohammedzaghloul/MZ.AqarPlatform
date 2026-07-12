using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.DTOs.Auth
{
    public class RegisterDto
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!; 
        public AccountType AccountType { get; set; }
    }
}
