using CaploittePayroll.BusinessObjects.AuthenticationModule;
using CaploittePayroll.DAL.AuthenticationModule;
using CaploittePayroll.DAL.Interface.AuthenticationModule;
using CaploittePayroll.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaploittePayroll.DAL.Interface.EmployeeModule;
using CaploittePayroll.DAL.EmployeeModule;
using CaploittePayroll.ApplicationServices.Common;
using CaploittePayroll.BusinessObjects.Common;
using CaploittePayroll.BusinessObjects.EmployeeModule;

namespace CaploittePayroll.ApplicationServices.EmployeeModule
{
    public class EmployeeApplicationService
    {
        IDataService dataService;
        public bool SaveEmployee(User user)
        {

            try
            {
                dataService = DataServiceBuilder.CreateDataService();
                IEmployeeDataService eds = new EmployeeDataService(dataService);
                user.Password = Guid.NewGuid().ToString("N");
                var loggedUser = eds.SaveUser(user);
                if (loggedUser)
                {
                    MailSender mailSender = new MailSender();
                    AutomateEmail automateEmail = new AutomateEmail();
                    automateEmail.TCPIP_Server = AppSettings.TcpipServer;
                    automateEmail.TCPIP_Port = Int32.Parse(AppSettings.TcpipPort);
                    automateEmail.SenderUserName = AppSettings.SenderUserName;
                    automateEmail.SenderPassword = AppSettings.SenderPassword;
                    automateEmail.Subject = "Welcome to CaploittePayroll";
                    automateEmail.MailTo = user.Email;
                    automateEmail.MailCC = AppSettings.MailCC;
                    automateEmail.FromAddress = AppSettings.FromAddress;

                    string message = $@"<div style=""font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px;"">
                                        <h1 style=""color: #0070cc;"">CaploittePayroll - Login Details</h1>
                                        <p>Hello {user.FullName},</p>
                                        <p> Here are your new login details:</p>
                                        <p><strong>Username:</strong> {user.Email}</p>
                                        <p><strong>Password:</strong> {user.Password}</p>
                                        <p>You can now log in to your CaploittePayroll account using the provided credentials.</p>
                                        <p>Please reset your password after successfuly loginto the system.</p>
                                        <p>Thank you for using CaploittePayroll!</p>
                                        <p>&copy; 2023 CaploittePayroll. All rights reserved.</p>
                                      </div>";

                    mailSender.SendMail(message, automateEmail);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<Employee> GetAllEmployee()
        {
            dataService = DataServiceBuilder.CreateDataService();
            IEmployeeDataService eds = new EmployeeDataService(dataService);
            return eds.GetEmployeeList();
        }
    }
}
