using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Models.ViewModel.DepartmentVM
{
    public class DepartmentViewModel
    {
        public string DName { get; set; }
        public int DNumber { get; set; }
        public string? MgrSsn { get; set; }
        public DateTime? Mgr_Start_Date { get; set; }



    }

    public class UpdateDepartmentViewModel
    {
        public string DName { get; set; }
        public string DNumber { get; set; }
        public char? MgrSsn { get; set; }
        public DateTime Mgr_Start_Date { get; set; }



    }
}
