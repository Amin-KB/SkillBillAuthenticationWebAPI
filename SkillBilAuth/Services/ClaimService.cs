using System.Security.Claims;
using System;
using SkillBilAuth.ResponseAndRequest;
using SkillBilAuth.Entities;

namespace SkillBilAuth.Services
{
    public static class ClaimService
    {
        internal static Claim[] GenerateClaims(User user)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.Name,user.FirstName + " "+user.LastName),
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Role,user.Role.ToString())
            };
            return claims;
        }
    }
}
