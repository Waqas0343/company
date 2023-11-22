using Company_Models.ViewModel.EmployeeVm;
using Company_Services.Employe;
using Microsoft.AspNetCore.Mvc;

namespace Company_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeData;

        public EmployeeController(IEmployee employeeData)
        {

            this.employeeData = employeeData;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {

            try
            {
                var data = await employeeData.GetEmployeesAsync();
                return Ok(data);
            }
            catch (Exception)
            {



                throw;
            }


        }


        [HttpPost("AddEmployees")]
        public async Task<IActionResult> AddEmployees(EmployeeViewModel model)
        {

            try
            {
                var data = await employeeData.AddEmployeesAsync(model);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetProductsByID")]
        public async Task<IActionResult> GetProductsByID(int id)
        {

            try
            {
                var data = await employeeData.GetEmployeesByIDAsyn(id);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeViewModel model)
        {

            try
            {
                var data = await employeeData.UpdateEmployeeAsyn(model);
                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteEmployeeByID")]
        public async Task<IActionResult> DeleteEmployeeByID(int id)
        {
            try
            {
                var data = await employeeData.DeleteEmployeesByIDAsyn(id);
                if (data is null)
                {
                    return Ok("Data Not Found");
                }

                return Ok(data);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
