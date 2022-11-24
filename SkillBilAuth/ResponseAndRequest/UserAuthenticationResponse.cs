using SkillBilAuth.Entities;

namespace SkillBilAuth.ResponseAndRequest
{
    public class UserAuthenticationResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
        public UserAuthenticationResponse(User user,string token)
        {
            User= user;
            Token= token;
        }
    }
}
