using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class CatalogSkill
    {
        public CatalogSkill()
        {
            CatalogSkillHistories = new HashSet<CatalogSkillHistory>();
            CustomersSkills = new HashSet<CustomersSkill>();
        }

        public int Id { get; set; }
        public string SkillName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int Points { get; set; }
        public bool IsLapRelevant { get; set; }
        public int AreaId { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<CatalogSkillHistory> CatalogSkillHistories { get; set; }
        public virtual ICollection<CustomersSkill> CustomersSkills { get; set; }
    }
}
