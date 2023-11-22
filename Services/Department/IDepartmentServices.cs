using Company_Models.ViewModel;
using Company_Models.ViewModel.DepartmentVM;
using System.Net.Http.Headers;

namespace Company_Services.DepartmentVM
{
    public interface IDepartmentServices
    {
        Task<Response<DepartmentViewModel>> GetDepartmentAsync();
        Task<Response<DepartmentViewModel>> AddDepartmentAsync(DepartmentViewModel model);

    }
}
