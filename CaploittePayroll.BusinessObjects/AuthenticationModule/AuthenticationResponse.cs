using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.BusinessObjects.AuthenticationModule
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(string role, string userName, string token) {

            this.UserName = userName;
            this.Role = role;
            this.JwtToken = token;
                }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string JwtToken { get; set; }
    }
}
