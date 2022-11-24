using System;
using System.Collections.Generic;

namespace SkillBilAuth.Models
{
    public partial class ViewCustomer
    {
        public int Id { get; set; }
        public string Vorname { get; set; } = null!;
        public string Nachname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefonnummer { get; set; }
        public bool Aktiv { get; set; }
        public string Gruppe { get; set; } = null!;
    }
}
