using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.BusinessObjects.AuthenticationModule
{
    public class User
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
}
