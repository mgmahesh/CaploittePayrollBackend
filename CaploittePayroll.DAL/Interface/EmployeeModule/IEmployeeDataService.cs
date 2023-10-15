using CaploittePayroll.BusinessObjects.AuthenticationModule;
using CaploittePayroll.BusinessObjects.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.DAL.Interface.EmployeeModule
{
    public interface IEmployeeDataService
    {
        bool SaveUser(User user);
        List<Employee> GetEmployeeList();
    }
}
