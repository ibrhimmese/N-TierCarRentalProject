using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    { 
        public static List<String>Claims(this ClaimsPrincipal claimPrincipal,string claimType)
        {
            var result =claimPrincipal?.FindAll(claimType)?.Select(p=>p.Value).ToList();
            return result;
        }

        public static List<string>ClaimsRoles(this ClaimsPrincipal claimPrincipal)  
        {
            return claimPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
