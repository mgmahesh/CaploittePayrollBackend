using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace CaploittePayroll.DAL
{
    public abstract class IDataService
    {
        public abstract void BeginTransaction();
        public abstract void CommitTransaction();
        public abstract void RollbackTransaction();
        public abstract void CloseConnection();
        public abstract int ExecuteNonQuery(string spName, DbParameter[] sqlParameters, int? timeout = null);
        public abstract DbDataReader ExecuteReader(string spName, DbParameter[] sqlParameters = null, int? timeout = null);
        public abstract object ExecuteScalar(string spName, DbParameter[] sqlParameters);
        public abstract void Dispose();
    }
}
