using SkillBilAuth.Entities;
using SkillBilAuth.Models;
using SkillBilAuth.ResponseAndRequest;
using System.Data;

namespace SkillBilAuth.Services
{
    public static class AspNetUserService
    {
        internal static bool AuthenticateUserFromDB(UserAuthenticationRequest userAuthenticationRequest)
        {
            using (var db = new SkillbillDbContext())
            {
                if (db.AspNetUsers.Any(x => x.NormalizedEmail == userAuthenticationRequest.Email.ToUpper()
                && x.PasswordHash == userAuthenticationRequest.Password))
                    return true;
                return false;

            }
        }
        internal static UserAuthenticationResponse GetUserFromDB(UserAuthenticationRequest userAuthenticationRequest)
        {
           
            using (var db = new SkillbillDbContext())
            {
                var request = db.AspNetUsers.FirstOrDefault(x =>
                x.NormalizedEmail == userAuthenticationRequest.Email.ToUpper()
                && x.PasswordHash == userAuthenticationRequest.Password);
                if (request != null)
                {

                    return new UserAuthenticationResponse(
                        Mapping(request),
                        TokenService.GenerateToken(Mapping(request)));
                }             
                 
                return null;
                
            }

        }

        private static User Mapping(AspNetUser AspUser)
        {
            
            var user = new User();
            user.PersonId = AspUser.Id;
            user.FirstName = AspUser.FirstName;
            user.LastName = AspUser.LastName;
            user.Email = AspUser.Email;
            user.Role =(int) GetUserRole(AspUser.Id);
            return user;    
            //userAuthenticationResponse.Token= TokenService.GenerateToken(AspUser)
            //return userAuthenticationResponse;

        }

        private static int? GetUserRole(int id)
        {
            SkillBilAuth.Services.FetchService.CreateTheConnection();
            int? RoleId = SkillBilAuth.Services.FetchService.GetUserRole(id);
            if (RoleId != null)
                return RoleId.Value;          
           return null;
            
        }
    }
}
