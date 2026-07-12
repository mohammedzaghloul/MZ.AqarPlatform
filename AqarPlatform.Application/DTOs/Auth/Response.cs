using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.DTOs.Auth
{
    public class Response<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

    }
}
