using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class Grade
    {
        public Grade()
        {
            CustomerSkillHistories = new HashSet<CustomerSkillHistory>();
            CustomersSkills = new HashSet<CustomersSkill>();
        }

        public int Id { get; set; }
        public string GradeName { get; set; } = null!;
        public int GradeNumber { get; set; }
        public int Percentage { get; set; }

        public virtual ICollection<CustomerSkillHistory> CustomerSkillHistories { get; set; }
        public virtual ICollection<CustomersSkill> CustomersSkills { get; set; }
    }
}
