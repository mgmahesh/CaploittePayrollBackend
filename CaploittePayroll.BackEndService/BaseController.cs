using CaploittePayroll.BusinessObjects.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System;

namespace CaploittePayroll.Web.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        
    }
}
