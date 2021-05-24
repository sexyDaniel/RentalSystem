using Microsoft.IdentityModel.Tokens;
using PapsCourse.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PapsCourse.Server.Models
{
    public static class JwtToken
    {
        public static string GetToken(User user)
        {
            var identity = GetIdentity(user);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: "Me",
                    audience: "I",
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(5)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("secret1232143321ewqe123213w21esw")), SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


        private static ClaimsIdentity GetIdentity(User user)
        {
            var claims = new List<Claim> {
                new Claim("Email",user.Email),
                new Claim("ID",user.Id.ToString()),
                new Claim("isAdmin",(user.Role=="Admin").ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
