using Dapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PickemWebAPI.Library.Internal.DataAccess
{
    public class SqlDataAccess
    {
        public string GetConnectionString(string csName)
        {
            return ConfigurationManager.ConnectionStrings[csName].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                List<T> rows = conn.Query<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
