using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Areas = new HashSet<Area>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public bool IsActive { get; set; }
        public int? GroupId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
    }
}
