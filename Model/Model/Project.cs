using System;
using System.Collections.Generic;

namespace Company_Models.Model
{
    public partial class Project
    {
        public Project()
        {
            WorksOns = new HashSet<WorksOn>();
        }

        public string Pname { get; set; } = null!;
        public int Pnumber { get; set; }
        public string? Plocation { get; set; }
        public int Dnum { get; set; }

        public virtual Department DnumNavigation { get; set; } = null!;
        public virtual ICollection<WorksOn> WorksOns { get; set; }
    }
}
