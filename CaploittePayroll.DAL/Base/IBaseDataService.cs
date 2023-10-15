using CaploittePayroll.BusinessObjects.Base;
using CaploittePayroll.BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CaploittePayroll.DAL.Base
{
    public interface IBaseDataService
    {
        List<ErrorMessage> GetErrorMessages();
    }
}
