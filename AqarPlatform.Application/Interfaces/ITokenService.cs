using AqarPlatform.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace AqarPlatform.Application.Interfaces
{
    public interface ITokenService
    {
       ResponseToken  CreateToken(CreateTokenFromate createTokenFromate);
    }
}
