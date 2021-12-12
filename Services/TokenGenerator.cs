using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using KibritAPI.Options;
using Microsoft.IdentityModel.Tokens;

namespace KibritAPI.Services
{
    public class TokenGenerator : ITokenGenerator
    {
        public string CreateJwtToken(string userName, string id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Email, userName),
                    new Claim(ClaimTypes.NameIdentifier,id)
                }),
                Expires = DateTime.Now.AddMinutes(AuthOptions.LIFETIME),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}