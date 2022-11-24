using SkillBilAuth.ResponseAndRequest;

namespace SkillBilAuth.Entities
{
    public class User 
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Role { get; set; }
        
    }
}
