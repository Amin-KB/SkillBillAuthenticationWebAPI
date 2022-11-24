using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class CatalogSkillHistory
    {
        public int Id { get; set; }
        public int CatalogSkillId { get; set; }
        public string SkillName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int Points { get; set; }
        public int AreaId { get; set; }
        public bool IsLapRelevant { get; set; }
        public DateTime? EditedOn { get; set; }
        public int EditedBy { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual CatalogSkill CatalogSkill { get; set; } = null!;
        public virtual AspNetUser EditedByNavigation { get; set; } = null!;
    }
}
