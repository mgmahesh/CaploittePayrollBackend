using CaploittePayroll.BusinessObjects.Common;
using JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaploittePayroll.BackendService.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                return new string[] { $"CaploittePayroll.BackendService | Environment [{Startup.EnvironmentName}] | Origin [{AppSettings.AllowedOrigin}]" };
            }
            catch (System.Exception ex)
            {
                return new string[] { ex.Message };
            }
        }
    }
}
