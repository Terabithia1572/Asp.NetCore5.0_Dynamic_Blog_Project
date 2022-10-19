using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_BlogProject.DAL
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("dynamicblogproject");
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:"http://localhost",audience:"http://localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials: credentials);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

        }
    }
}
