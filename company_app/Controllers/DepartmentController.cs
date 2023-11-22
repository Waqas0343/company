using Company_Models.ViewModel.DepartmentVM;
using Company_Services.DepartmentVM;
using Microsoft.AspNetCore.Mvc;

namespace Company_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices dapartmentData;

        public DepartmentController(IDepartmentServices dapartmentData)
        {

            this.dapartmentData = dapartmentData;
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {

            try
            {
                var data = await dapartmentData.GetDepartmentAsync();
                return Ok(data);
            }
            catch (Exception)
            {



                throw;
            }


        }
        [HttpPost("AddDepartments")]
        public async Task<IActionResult> AddDepartments(DepartmentViewModel model)
        {

            try
            {
                var data = await dapartmentData.AddDepartmentAsync(model);
                return Ok(data);
            }
            catch (Exception)
            {



                throw;
            }


        }

    }
}
