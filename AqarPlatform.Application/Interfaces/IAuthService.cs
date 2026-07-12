using AqarPlatform.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.Interfaces
{
    public interface IAuthService
    {
       Task<Response<AuthResponseDto>> LoginAsync(LoginDto loginDto);
        Task<Response<AuthResponseDto>> RegisterAsync(RegisterDto registerDto);
        Task<Response<AuthResponseDto>> RegisterAdminAsync(RegisterDto registerDto);
    }
}
