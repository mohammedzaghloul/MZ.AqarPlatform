using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Shared
{
    public class ResponseToken
    {
        public string AccessToken { get; set; } = string.Empty;

        public DateTime ExpireAt { get; set; }
    }
}
