using System;
using System.Collections.Generic;

namespace Company_Models.Model
{
    public partial class WorksOn
    {
        public char Essn { get; set; }
        public int Pno { get; set; }
        public decimal? Hours { get; set; }

        public virtual Employee EssnNavigation { get; set; } = null!;
        public virtual Project PnoNavigation { get; set; } = null!;
    }
}
