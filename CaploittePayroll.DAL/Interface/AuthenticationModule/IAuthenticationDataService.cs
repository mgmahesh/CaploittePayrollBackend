using CaploittePayroll.BusinessObjects.AuthenticationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.DAL.Interface.AuthenticationModule
{
    public interface IAuthenticationDataService
    {
        LoggedUser UserLogin(AccessTokenRequest atr);
    }
}
