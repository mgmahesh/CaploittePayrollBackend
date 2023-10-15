using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CaploittePayroll.BusinessObjects.Common;

namespace CaploittePayroll.ApplicationServices.Common
{
    internal class MailSender
    {
        internal static List<string> BreakDown(string strInput)
        {
            List<string> list = new List<string>(strInput.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            return list;
        }

        public int SendMail(string message, AutomateEmail automateEmailData)
        {
            int retInt = 0;
            string _sender = null, _sendermail = null, _password = null, _host = null, _recipient = null, _ccRecipt = null, _subject = null;
            int _port = 0;
            List<string> recipient = new List<string>();
            List<string> ccRecipt = new List<string>();



            _sendermail = automateEmailData.FromAddress;
            _sender = automateEmailData.SenderUserName;
            _password = automateEmailData.SenderPassword;
            _host = automateEmailData.TCPIP_Server;// dr["TCPIP_Server"].ToString();
            _port = automateEmailData.TCPIP_Port;//Convert.ToInt32(dr["TCPIP_Port"]);

            _subject = automateEmailData.Subject;//dr["Subject"].ToString();
            _recipient = automateEmailData.MailTo;//dr["MailTo"].ToString().Replace(" ", string.Empty);
            _ccRecipt = automateEmailData.MailCC;//dr["MailCC"].ToString().Replace(" ", string.Empty);

            recipient = BreakDown(_recipient);
            ccRecipt = BreakDown(_ccRecipt);



            DateTime date = DateTime.Now;
            string footer = @"<div style=""font-size: 14px; text-align: center; background-color: #f7f7f7; padding: 20px 0;"">
                            <p>Thank you for using <strong>CaploittePayroll</strong></p>
                            <p>&copy; 2023 CaploittePayroll. All rights reserved.</p>
                            <p>Contact us at <a style=""text-decoration: none; color: #0070cc;"" href=""mailto:info@caploittepayroll.com"">info@caploittepayroll.com</a></p>
                            </div>";

            SmtpClient client = new SmtpClient
            {
                Host = _host,
                Port = _port,

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_sender, _password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(_sendermail),
                    Subject = _subject,
                    BodyEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };

                if (recipient != null || recipient.ToArray().Length != 0)
                {
                    foreach (string a in recipient)
                    {
                        mail.To.Add(a.ToString());
                    }
                }

                if (ccRecipt != null || ccRecipt.ToArray().Length != 0)
                {
                    foreach (string a in ccRecipt)
                    {
                        mail.CC.Add(a.ToString());
                    }
                }

                mail.Body = message + footer;

                client.Send(mail);
                mail.Dispose();
                mail = null;
                client = null;

                retInt = 1;


            }
            catch (Exception ex)
            {

            }
            return retInt;
        }
    }
}
