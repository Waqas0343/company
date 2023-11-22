using Company_Models.ViewModel;
using Company_Models.ViewModel.EmployeeVm;

namespace Company_Services.Employe;

public interface IEmployee
{
    Task<Response<EmployeeViewModel>> GetEmployeesAsync();
    Task<Response<EmployeeViewModel>> AddEmployeesAsync(EmployeeViewModel model);
    Task<Response<EmployeeViewModel>> GetEmployeesByIDAsyn(int id);
    Task<Response<EmployeeViewModel>> UpdateEmployeeAsyn(UpdateEmployeeViewModel model);
    Task<Response<EmployeeViewModel>> DeleteEmployeesByIDAsyn(int id);
}
