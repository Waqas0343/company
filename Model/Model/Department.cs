using System;
using System.Collections.Generic;

namespace Company_Models.Model
{
    public partial class Department
    {
        public Department()
        {
            DeptLocations = new HashSet<DeptLocation>();
            Employees = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }

        public string Dname { get; set; } = null!;
        public int Dnumber { get; set; }
        public string MgrSsn { get; set; } = null!;
        public DateTime? MgrStartDate { get; set; }

        public virtual ICollection<DeptLocation> DeptLocations { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
