using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.BusinessObjects.AuthenticationModule
{
    public class AccessTokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
