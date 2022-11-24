using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class Group
    {
        public Group()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime BeginAktOn { get; set; }
        public DateTime EndAktOn { get; set; }
        public int EducationId { get; set; }

        public virtual Education Education { get; set; } = null!;
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
