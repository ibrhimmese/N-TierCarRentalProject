using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Claims;
using Core.Extensions;

namespace Core.Utilities.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration Configuration;

        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateToken(User user, List<OperationClaim> operationClaims)
        {
            Token token = new Token();

            //Security key symetric 
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));


            //Şifrelenmiş kimlik

            SigningCredentials signingCredentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);

            //token settings
            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires: token.Expiration,
                claims:SetClaims(user,operationClaims),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials

                );

            //token oluşturucu sınıftan örnek almamız gerek
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            //Token Create
            token.AccessToken=jwtSecurityTokenHandler.WriteToken(securityToken);

            //Refresh Token Create
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number=new byte[32];
            using (RandomNumberGenerator random=RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim>operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddName(user.Name);
            claims.AddRoles(operationClaims.Select(p=> p.Name).ToArray());
            return claims;
        }
    }
}
