using Company_Data.AppContext;
using Company_Models.Model;
using Company_Models.ViewModel;
using Company_Models.ViewModel.DepartmentVM;
using Microsoft.EntityFrameworkCore;

namespace Company_Services.DepartmentVM
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly CompanyDBContext db;
        public DepartmentServices(CompanyDBContext db)
        {
            this.db = db;
        }
        public async Task<Response<DepartmentViewModel>> GetDepartmentAsync()
        {

            try
            {
                var data = await db.Departments.Select(s => new DepartmentViewModel
                {
                    DName = s.Dname,
                    MgrSsn = s.MgrSsn,
                    Mgr_Start_Date = s.MgrStartDate,
                    DNumber = s.Dnumber

                }).ToListAsync();

                return new Response<DepartmentViewModel>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                    List = data

                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<Response<DepartmentViewModel>> AddDepartmentAsync(DepartmentViewModel model)
        {
            try
            {
                Department department = new Department();
                department.Dname = model.DName;
                department.Dnumber = model.DNumber;
                department.MgrSsn = model.MgrSsn;
                department.MgrStartDate = model.Mgr_Start_Date;
                await db.Departments.AddAsync(department);
                await db.SaveChangesAsync();
                return new Response<DepartmentViewModel>

                {

                    Message = "Department Add Successfully!",
                    Status = true,
                };

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
