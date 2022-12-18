using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repo;

namespace Business
{
    public class BusinessLoginUser : IBusinessLoginUser
    {
        private readonly IRepoLoginUser _IRepoLoginUser;

        public BusinessLoginUser(IRepoLoginUser irepoLoginUser)
        {
            _IRepoLoginUser = irepoLoginUser;
        }

        public string LoginUser(DtoLogin dtoLogin)
        {
            string result = _IRepoLoginUser.LoginUser(dtoLogin);
            if (!result.Equals("false"))
            {
                #region Authentication
                var claims = new[]
                {
                new Claim(ClaimTypes.Email, dtoLogin.email),
                new Claim(ClaimTypes.Role, result)
                };

                var token = new JwtSecurityToken
                (
                    issuer: "https://localhost:5117",
                    audience: "https://localhost:5117",
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
                        SecurityAlgorithms.HmacSha256)
                );

                string LoginToken = new JwtSecurityTokenHandler().WriteToken(token);
                return LoginToken;
                #endregion
            }
            else
            {
                return "User not found";
            }
        }
    }
}