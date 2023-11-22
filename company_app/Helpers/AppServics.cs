using Company_Services.DepartmentVM;
using Company_Services.Employe;
using Company_Services.Employees;

namespace Company_App.Helpers
{
    public static class AppServics
    {
       public static IServiceCollection Addappservices(this IServiceCollection appservices)
        {
            appservices.AddTransient<IEmployee, EmployeeServices>();
            appservices.AddTransient<IDepartmentServices, DepartmentServices>();
         
            return appservices;

        }
    }
}
