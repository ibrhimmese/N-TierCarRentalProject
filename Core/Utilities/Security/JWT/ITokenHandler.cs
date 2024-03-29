﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
