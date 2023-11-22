using Company_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Models.ViewModel.EmployeeVm
{
    public class EmployeeViewModel
    {
        public string? Fname { get; set; }
        public string? Minit { get; set; }
        public string? Lname { get; set; }
        public char Ssn { get; set; }
        public DateTime? Bdate { get; set; }
        public string? Address { get; set; }
        public string? Sex { get; set; }
        public decimal? Salary { get; set; }
        public char? Super_ssn { get; set; }
        public int? Dno { get; set; }



    }

    public class UpdateEmployeeViewModel
    {
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public char Ssn { get; set; }
        public DateTime Bdate { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public decimal Salary { get; set; }
        public char? Super_ssn { get; set; }
        public int Dno { get; set; }
    }
}
