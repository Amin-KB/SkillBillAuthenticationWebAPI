using Microsoft.IdentityModel.Tokens;
using SkillBilAuth.Helpers;
using SkillBilAuth.Models;
using SkillBilAuth.ResponseAndRequest;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using SkillBilAuth.Entities;

namespace SkillBilAuth.Services
{
   
    public static class TokenService
    {
        private static readonly AppSetting _appSettings;
        internal static string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("z3EFuUwlgcXRXkrcALN9cfcoOs6MBHkK"));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var claims = ClaimService.GenerateClaims(user);
            var token = new JwtSecurityToken
                (
                claims.ToString(),
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credential
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }  
}
