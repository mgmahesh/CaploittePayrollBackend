using System;
using System.Collections.Generic;
using System.Text;

namespace CaploittePayroll.BusinessObjects.Common
{
    public class ApiError
    {
        private string _errorCode;
        private string _errorMessage;
        private AppEnum.ErrorType _errorType;
        public string StatusMessage { get { return _errorCode; } }
        public AppEnum.ErrorType ErrorType { get { return _errorType; } }
        public string ErrorMessage { get { return _errorMessage; } }

        public ApiError(string errorCode, AppEnum.ErrorType eErrorType, string errorMessage)
        {
            _errorCode = errorCode;
            _errorType = eErrorType;
            _errorMessage = errorMessage;
        }
    }
}
