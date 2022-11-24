using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class Education
    {
        public Education()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string EducationName { get; set; } = null!;
        public bool IsActive { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
