using System;
using System.Collections.Generic;

namespace Company_Models.Model
{
    public partial class DeptLocation
    {
        public int Dnumber { get; set; }
        public string Dlocation { get; set; } = null!;

        public virtual Department DnumberNavigation { get; set; } = null!;
    }
}
