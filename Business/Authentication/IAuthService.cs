﻿using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication
{
    public interface IAuthService
    {
        IResult Register(RegisterAuthDto registerDto);
        IDataResult<Token> Login(LoginAuthDto loginDto);
    }
}
