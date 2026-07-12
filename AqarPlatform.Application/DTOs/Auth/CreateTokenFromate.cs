using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Shared
{
    public class CreateTokenFromate
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string>  Roles {  get; set; } = null!;

    }
}
