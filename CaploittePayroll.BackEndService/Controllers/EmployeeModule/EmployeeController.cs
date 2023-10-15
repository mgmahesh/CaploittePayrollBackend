using CaploittePayroll.ApplicationServices.AuthenticationModule;
using CaploittePayroll.ApplicationServices.EmployeeModule;
using CaploittePayroll.BusinessObjects.AuthenticationModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaploittePayroll.BackendService.Controllers.EmployeeModule
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        [ActionName("InsertEmployee")]
        public IActionResult SaveEmployee([FromBody] User userDetails)
        {
            EmployeeApplicationService apiUserAS = new EmployeeApplicationService();
             var result = apiUserAS.SaveEmployee(userDetails);

            if (!result)
            {
                return Forbid();
            }

            return Ok(new
            {
                StatusCode = 200
            });
        }

        [HttpGet]
        [ActionName("GetEmployeeList")]
        public IActionResult GetEmployeeList()
        {
            EmployeeApplicationService apiUserAS = new EmployeeApplicationService();
            var result = apiUserAS.GetAllEmployee();

            return Ok(new
            {
                result
            });
        }
    }
}
