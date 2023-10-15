using CaploittePayroll.BusinessObjects.Base;
using CaploittePayroll.BusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CaploittePayroll.DAL.Base
{
    public class BaseDataService : IBaseDataService
    {
        IDataService _dataService;
        public BaseDataService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public List<ErrorMessage> GetErrorMessages()
        {
            List<ErrorMessage> errorList = new List<ErrorMessage>();
            
                return errorList;
            
        }
    }
}
