using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.BusinessObjects.AuthenticationModule
{
    public class LoggedUser
    {
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
