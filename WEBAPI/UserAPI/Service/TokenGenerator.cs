using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace UserAPI.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int id, string name)
        {
            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,name)

            };
            var userSecurityKey = Encoding.UTF8.GetBytes("kjhfdertgfhgfdsawertyuiokjhgnbvb");
            var userSymmetricSecurity = new SymmetricSecurityKey(userSecurityKey);
            var userSigninCredentials = new SigningCredentials(userSymmetricSecurity, SecurityAlgorithms.HmacSha256);
            var userJwtSecurityToken = new JwtSecurityToken
                (
                    issuer: "ProductApp",
                    audience: "coreMVCuser",
                    claims: userClaims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: userSigninCredentials
                );
            var userSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);
           string userJwtSecurityTokenHandler =  JsonConvert.SerializeObject(new {Token = userSecurityTokenHandler});
            return userJwtSecurityTokenHandler;
        }
    }
}
