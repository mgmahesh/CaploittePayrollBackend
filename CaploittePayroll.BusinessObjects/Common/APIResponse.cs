using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CaploittePayroll.BusinessObjects.Common
{
    public class APIResponse
    {
        private object _result;
        private List<ApiError> _errorList;
        private HttpStatusCode _statusCode;

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }

        public List<ApiError> ErrorList
        {
            get { return _errorList; }
        }

        public object Result
        {
            get { return _result; }
        }
        public APIResponse(string messageCode, object result, AppEnum.ErrorType errorType, HttpStatusCode statusCode, bool showMessage)
        {
            _result = result;
            _statusCode = statusCode;
            var errorMessage = string.Empty;
            if (showMessage)
            {
                errorMessage = string.Empty; 
            }

            ApiError error = new ApiError(messageCode, errorType, errorMessage);
            _errorList = new List<ApiError>();
            _errorList.Add(error);
        }
    }
}
