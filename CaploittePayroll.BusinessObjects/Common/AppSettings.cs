using System;
using System.Collections.Generic;
using System.Text;

namespace CaploittePayroll.BusinessObjects.Common
{
    public static class AppSettings
    {
        public static string AllowedOrigin { get; set; }
        public static string ConnectionString { get; set; }
        public static string TokenTimout { get; set; }
        public static string Secret { get; set; }
        public static string TcpipServer { get; set; }
        public static string TcpipPort { get; set; }
        public static string SenderUserName { get; set; }
        public static string SenderPassword { get; set; }
        public static string MailCC { get; set; }
        public static string FromAddress { get; set; }
    }
}
