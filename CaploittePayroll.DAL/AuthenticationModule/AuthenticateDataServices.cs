using CaploittePayroll.BusinessObjects.AuthenticationModule;
using CaploittePayroll.DAL.Interface.AuthenticationModule;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaploittePayroll.DAL.AuthenticationModule
{
    public class AuthenticateDataServices: IAuthenticationDataService
    {
        IDataService _dataService;
        public AuthenticateDataServices(IDataService dataService)
        {
            _dataService = dataService;
        }

        public LoggedUser UserLogin(AccessTokenRequest atr)
        {
            try
            {
                LoggedUser logeduser = new LoggedUser();
                DbParameter[] arrSqlParam = new DbParameter[2];
                arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@Email", System.Data.DbType.String, System.Data.ParameterDirection.Input, atr.Username == null ? "" : atr.Username);
                arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@Password", System.Data.DbType.String, System.Data.ParameterDirection.Input, atr.Password == null ? "" : atr.Password);

                DbDataReader reader = _dataService.ExecuteReader("[um].[UserLogin]", arrSqlParam);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataReader dataReader = new DataReader(reader);
                        logeduser.FullName = dataReader.GetString("FullName");
                        logeduser.RoleName = dataReader.GetString("RoleName");
                        logeduser.UserName = dataReader.GetString("UserName");
                    }
                    reader.Close();
                }
                return logeduser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool ChangePassword()
        //{
        //    try
        //    {
        //        DbParameter[] arrSqlParam = new DbParameter[3];
        //        arrSqlParam[0] = DataServiceBuilder.CreateDBParameter("@EmployeeId", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, employeeId);
        //        arrSqlParam[1] = DataServiceBuilder.CreateDBParameter("@IsSalaryHold", System.Data.DbType.Boolean, System.Data.ParameterDirection.Input, isSalaryHold);
        //        arrSqlParam[2] = DataServiceBuilder.CreateDBParameter("@UserID", System.Data.DbType.Int32, System.Data.ParameterDirection.Input, UserID);
        //        _dataService.ExecuteNonQuery("um.SaveSalaryHoldUsers", arrSqlParam);

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

    }
}
