using Company_Data.AppContext;
using Company_Models.Model;
using Company_Models.ViewModel;
using Company_Models.ViewModel.EmployeeVm;
using Company_Services.Employe;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace Company_Services.Employees
{
    public class EmployeeServices : IEmployee
    {
        private readonly CompanyDBContext db;


        public EmployeeServices(CompanyDBContext db)
        {
            this.db = db;
        }
        public async Task<Response<EmployeeViewModel>> GetEmployeesAsync()
        {

            try
            {
                var data = await db.Employees.Select(s => new EmployeeViewModel
                {
                    Fname = s.Fname,
                    Minit = s.Minit,
                    Lname = s.Lname,
                    Ssn = s.Ssn,
                    Bdate = s.Bdate,
                    Address = s.Address,
                    Sex = s.Sex,
                    Salary = s.Salary,
                    Super_ssn = s.SuperSsn,
                    Dno = s.Dno,


                }).ToListAsync();

                return new Response<EmployeeViewModel>
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

        public async Task<Response<EmployeeViewModel>> AddEmployeesAsync(EmployeeViewModel model)
        {
            try
            {
                Employee employee = new Employee();
                employee.Fname = model.Fname;
                employee.Minit = model.Minit;
                employee.Lname = model.Lname;
                employee.Ssn = model.Ssn;
                employee.Bdate = model.Bdate;
                employee.Address = model.Address;
                employee.Sex = model.Sex;
                employee.Salary = model.Salary;
                employee.SuperSsn = model.Super_ssn;
                employee.Dno = model.Dno;



                await db.Employees.AddAsync(employee);
                await db.SaveChangesAsync();
                return new Response<EmployeeViewModel>

                {

                    Message = "Employee Add Successfully!",
                    Status = true,
                };

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Response<EmployeeViewModel>> GetEmployeesByIDAsyn(int id)
        {
            try
            {
                var data = await db.Employees.Where(x => x.Ssn == id).Select(s => new EmployeeViewModel
                {
                    Fname = s.Fname,
                    Minit = s.Minit,
                    Lname = s.Lname,
                    Ssn = s.Ssn,
                    Bdate = s.Bdate,
                    Address = s.Address,
                    Sex = s.Sex,
                    Salary = s.Salary,
                    Super_ssn = s.SuperSsn,
                    Dno = s.Dno,



                }).FirstOrDefaultAsync();
                return new Response<EmployeeViewModel>
                {
                    Message = "Data Get Successfully",
                    Status = true,
                    Data = data,


                };

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<Response<EmployeeViewModel>> UpdateEmployeeAsyn(UpdateEmployeeViewModel model)
        {
            try
            {
                var data = await db.Employees.Where(x => x.Ssn == model.Ssn).FirstOrDefaultAsync();


                data.Fname = model.Fname;
                data.Minit = model.Minit;
                data.Lname = model.Lname;
                data.Ssn = model.Ssn;
                data.Bdate = model.Bdate;
                data.Address = model.Address;
                data.Sex = model.Sex;
                data.Salary = model.Salary;
                data.SuperSsn = model.Super_ssn;
                data.Dno = model.Dno;

                db.Employees.Update(data);
                await db.SaveChangesAsync();

                return new Response<EmployeeViewModel>
                {
                    Message = "Data Update Successfully",
                    Status = true,

                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<EmployeeViewModel>> DeleteEmployeesByIDAsyn(int id)
        {
            try
            {
                var data = await db.Employees.Where(x => x.Ssn == id).FirstOrDefaultAsync();

                db.Employees.Remove(data);
                await db.SaveChangesAsync();

                return new Response<EmployeeViewModel>
                {
                    Message = "Data Delete Successfully",
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
