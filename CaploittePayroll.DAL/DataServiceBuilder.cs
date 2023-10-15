using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.SqlClient;
using CaploittePayroll.DAL.Base;

namespace CaploittePayroll.DAL
{
    public class DataServiceBuilder
    {
        public static IDataService CreateDataService()
        {
            return new SqlDataService();
        }
        public static IDataService CreateDataService(string ConnectionStringData)
        {
            return new SqlDataService();
        }

        public static DbParameter CreateDBParameter(string paramName, DbType paramType, ParameterDirection paramDirection, object value, [Optional] int size, [Optional] bool isImageType)
        {
            SqlParameter param = new SqlParameter();
            if (isImageType)
                param.SqlDbType = SqlDbType.Image;
            else
                param.DbType = paramType;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;

            if (value == null)
                param.Value = DBNull.Value;
            if (size != 0)
                param.Size = size;
            return param;

        }
        public static DbParameter CreateDataListParameter(string paramName, ParameterDirection paramDirection, object value)
        {
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Structured;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;
            if (value == null)
                param.Value = DBNull.Value;
            return param;

        }
        public static DbParameter CreateImageDBParameter(string paramName, ParameterDirection paramDirection, object value)
        {
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.Image;
            param.ParameterName = paramName;
            param.Direction = paramDirection;
            param.Value = value;
            if (value == null)
                param.Value = DBNull.Value;
            return param;

        }

        public static IBaseDataService CreateBaseDataService(IDataService dataService)
        {
            IBaseDataService baseDataService = new BaseDataService(dataService);
            return baseDataService;
        }

        internal static DbParameter CreateDBParameter1(string paramName, SqlDbType structured, ParameterDirection paramDirection, object dataTable, [Optional] int size, [Optional] bool isImageType, [Optional] byte precision, [Optional] byte scale)
        {
            SqlParameter param = new SqlParameter();
            try
            {

                if (isImageType)
                    param.SqlDbType = SqlDbType.Image;
                else
                    param.SqlDbType = structured;
                param.ParameterName = paramName;
                param.Direction = paramDirection;
                param.Value = dataTable;
                param.Precision = precision;
                param.Scale = scale;


                if (dataTable == null)
                    param.Value = DBNull.Value;
                if (size != 0)
                    param.Size = size;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return param;
        }


        private static DbParameter CreateParameter(string name, DbType dbType, object value = null, ParameterDirection direction = ParameterDirection.Input) => new SqlParameter { DbType = dbType, ParameterName = name, Value = value ?? DBNull.Value, Direction = direction };
        private static DbParameter CreateParameter(string name, DbType dbType, object value = null, ParameterDirection direction = ParameterDirection.Input, int size = 1)
        {
            var param = new SqlParameter { DbType = dbType, ParameterName = name, Value = value ?? DBNull.Value, Direction = direction };
            if (size > 1)
                param.Size = size;
            return param;
        }

        /// <summary>
        /// Creates byte parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter ByteParameter(string name, Byte? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Byte, value, direction);

        /// <summary>
        /// Creates short(int16) parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter ShortParameter(string name, Int16? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Int16, value, direction);

        /// <summary>
        /// Creates int(int32) parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter IntParameter(string name, Int32? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Int32, value, direction);

        /// <summary>
        /// Creates long(in64) parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter LongParameter(string name, Int64? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Int64, value, direction);

        /// <summary>
        /// Creates decimal parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter DecimalParameter(string name, Decimal? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Decimal, value, direction);

        /// <summary>
        /// Creates string parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static DbParameter StringParameter(string name, string value = null, ParameterDirection direction = ParameterDirection.Input, int size = 1) => CreateParameter(name, DbType.String, value, direction, size);

        /// <summary>
        /// Creates boolean parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter BooleanParameter(string name, bool? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Boolean, value, direction);

        /// <summary>
        /// Creates datetime parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter DateTimeParameter(string name, DateTime? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.DateTime, value, direction);

        /// <summary>
        /// Creates time span parameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter TimeSpanParameter(string name, TimeSpan? value = null, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(name, DbType.Time, value, direction);

        /// <summary>
        /// Creates guid parameter
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static DbParameter GuidParameter(string paramName, Guid? value, ParameterDirection direction = ParameterDirection.Input) => CreateParameter(paramName, DbType.Guid, value, direction);

    }
}
