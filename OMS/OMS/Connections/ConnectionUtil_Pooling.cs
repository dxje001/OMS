﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;

namespace OMS.ConnectionPool
{
    public class ConnectionUtil_Pooling : IDisposable
    {
        private static IDbConnection instance = null;

        public static IDbConnection GetConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
                ocsb.DataSource = Connections.ConnectionParams.LOCAL_DATA_SOURCE;
                ocsb.UserID = Connections.ConnectionParams.USER_ID;
                ocsb.Password = Connections.ConnectionParams.PASSWORD;
                //https://docs.oracle.com/database/121/ODPNT/featConnecting.htm#ODPNT163
                ocsb.Pooling = true;
                ocsb.MinPoolSize = 1;
                ocsb.MaxPoolSize = 10;
                ocsb.IncrPoolSize = 3;
                ocsb.ConnectionLifeTime = 5;
                ocsb.ConnectionTimeout = 30;
                instance = new OracleConnection(ocsb.ConnectionString);

            }
            return instance;
        }

        public void Dispose()
        {
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
            }

        }
    }
}
