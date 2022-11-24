using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class Area
    {
        public Area()
        {
            CatalogSkillHistories = new HashSet<CatalogSkillHistory>();
            CatalogSkills = new HashSet<CatalogSkill>();
            CustomerSkillHistories = new HashSet<CustomerSkillHistory>();
            CustomersSkills = new HashSet<CustomersSkill>();
        }

        public int Id { get; set; }
        public string AreaName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; } = null!;
        public virtual ICollection<CatalogSkillHistory> CatalogSkillHistories { get; set; }
        public virtual ICollection<CatalogSkill> CatalogSkills { get; set; }
        public virtual ICollection<CustomerSkillHistory> CustomerSkillHistories { get; set; }
        public virtual ICollection<CustomersSkill> CustomersSkills { get; set; }
    }
}
