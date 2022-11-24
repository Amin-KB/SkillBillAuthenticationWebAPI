using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class CustomerSkillHistory
    {
        public int Id { get; set; }
        public int CustomersSkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public int Points { get; set; }
        public int? GradeId { get; set; }
        public bool IsLapRelevant { get; set; }
        public int? AreaId { get; set; }
        public bool AssignActive { get; set; }
        public DateTime? EditedOn { get; set; }
        public int EditedBy { get; set; }

        public virtual Area? Area { get; set; }
        public virtual CustomersSkill CustomersSkill { get; set; } = null!;
        public virtual AspNetUser EditedByNavigation { get; set; } = null!;
        public virtual Grade? Grade { get; set; }
    }
}
