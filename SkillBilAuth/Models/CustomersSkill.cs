using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class CustomersSkill
    {
        public CustomersSkill()
        {
            CustomerSkillHistories = new HashSet<CustomerSkillHistory>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string SkillName { get; set; } = null!;
        public int Points { get; set; }
        public int? GradeId { get; set; }
        public int? CatalogSkillId { get; set; }
        public bool IsLapRelevant { get; set; }
        public int? AreaId { get; set; }
        public bool AssignActive { get; set; }

        public virtual Area? Area { get; set; }
        public virtual CatalogSkill? CatalogSkill { get; set; }
        public virtual AspNetUser Customer { get; set; } = null!;
        public virtual Grade? Grade { get; set; }
        public virtual ICollection<CustomerSkillHistory> CustomerSkillHistories { get; set; }
    }
}
