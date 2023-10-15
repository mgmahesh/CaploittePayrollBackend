using System;
using System.Collections.Generic;
using System.Text;

namespace CaploittePayroll.BusinessObjects.Base
{
    public class ErrorMessage
    {
        public string ErrorID { get; set; }
        public string ErrorDescription { get; set; }
        public int LanguageID { get; set; }
    }
}
