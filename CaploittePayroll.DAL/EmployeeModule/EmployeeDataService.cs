using CaploittePayroll.BusinessObjects.AuthenticationModule;
using CaploittePayroll.BusinessObjects.EmployeeModule;
using CaploittePayroll.DAL.Interface.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.DAL.EmployeeModule
{
    public class EmployeeDataService : IEmployeeDataService
    {
        IDataService _dataService;
        public EmployeeDataService(IDataService dataService)
        {
            _dataService = dataService;
        }
        public bool SaveUser(User user)
        {
            try
            {
                DbParameter[] arrSqlParam = new DbParameter[5];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@FullName", System.Data.DbType.String, System.Data.ParameterDirection.Input, user.FullName);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@Email", System.Data.DbType.String, System.Data.ParameterDirection.Input, user.Email);
                arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@JoinDate", System.Data.DbType.Date, System.Data.ParameterDirection.Input, user.JoinDate);
                arrSqlParam[3] = DataServiceBuilder.CreateDBParameter("@Password", System.Data.DbType.String, System.Data.ParameterDirection.Input, user.Password);
                arrSqlParam[4] = DataServiceBuilder.CreateDBParameter("@RoleId", System.Data.DbType.String, System.Data.ParameterDirection.Input, user.RoleId);
                _dataService.ExecuteNonQuery("[um].[InsertEmployee]", arrSqlParam);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                List<Employee> empList = new List<Employee>();
                DbDataReader reader = _dataService.ExecuteReader("[um].[GetEmployeeList]", null);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Employee emp = new Employee();
                        DataReader dataReader = new DataReader(reader);
                        emp.FullName = dataReader.GetString("FullName");
                        emp.Email = dataReader.GetString("Email");
                        emp.JoinDate = dataReader.GetString("JoinDate");

                        empList.Add(emp);
                    }
                    reader.Close();
                }
                return empList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
