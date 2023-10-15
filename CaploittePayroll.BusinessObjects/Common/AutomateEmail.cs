using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.BusinessObjects.Common
{
    public class AutomateEmail
    {
            public string FromAddress { get; set; }
            public string SenderUserName { get; set; }
            public string SenderPassword { get; set; }
            public string TCPIP_Server { get; set; }
            public int TCPIP_Port { get; set; }
            public string Subject { get; set; }
            public string MailTo { get; set; }
            public string MailCC { get; set; }
            
        
    }
}
