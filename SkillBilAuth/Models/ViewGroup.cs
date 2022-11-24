using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class ViewGroup
    {
        public int Id { get; set; }
        public string Gruppe { get; set; } = null!;
        public DateTime AktBeginn { get; set; }
        public DateTime AktEnde { get; set; }
        public string Ausbildung { get; set; } = null!;
    }
}
