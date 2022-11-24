using System.ComponentModel.DataAnnotations;

namespace SkillBilAuth.ResponseAndRequest
{
    public class UserAuthenticationRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public UserAuthenticationRequest(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
