using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Shared
{
    public class ResponseToken
    {
        public string Token { get; set; } = string.Empty;

        public DateTime Expiration  { get; set; }
    }
}
