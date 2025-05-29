using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JWTTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel userViewModel)
        {
            var claims = new List<Claim>();

            // SUB claim (JWT standard claim)
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, userViewModel.Id));

            // Role varsa ekle
            if (!string.IsNullOrWhiteSpace(userViewModel.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, userViewModel.Role));
            }

            // NameIdentifier (kendi sistemin için ek bir id)
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userViewModel.Id));

            // Username varsa ekle
            if (!string.IsNullOrWhiteSpace(userViewModel.UserName))
            {
                claims.Add(new Claim("Username", userViewModel.UserName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTTokenDefaults.Key));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JWTTokenDefaults.ExpireMinutes);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JWTTokenDefaults.ValidIssuer,
                audience: JWTTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate);
        }

    }
}
