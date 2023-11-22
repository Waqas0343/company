using System;
using System.Collections.Generic;

namespace Company_Models.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Dependents = new HashSet<Dependent>();
            InverseSuperSsnNavigation = new HashSet<Employee>();
            WorksOns = new HashSet<WorksOn>();
        }

        public string Fname { get; set; } = null!;
        public string? Minit { get; set; }
        public string Lname { get; set; } = null!;
        public char Ssn { get; set; }
        public DateTime? Bdate { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }
        public decimal? Salary { get; set; }
        public char? SuperSsn { get; set; }
        public int? Dno { get; set; }

        public virtual Department? DnoNavigation { get; set; }
        public virtual Employee? SuperSsnNavigation { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }
        public virtual ICollection<Employee> InverseSuperSsnNavigation { get; set; }
        public virtual ICollection<WorksOn> WorksOns { get; set; }
    }
}
