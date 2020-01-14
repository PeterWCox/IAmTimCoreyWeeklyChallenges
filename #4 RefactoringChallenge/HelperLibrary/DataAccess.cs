using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public static class DataAccess
    {
        public static string GetConnectionString(string connectionString = "DapperDemoDB")
        {
            return ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;
        }

        public static void CreateUser(string firstName, string lastName)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var p = new
                {
                    FirstName = firstName,
                    LastName = lastName,
                };

                cnn.Execute("dbo.spSystemUser_Create", p, commandType: CommandType.StoredProcedure);
            }
        }

        public static List<SystemUserModel> GetRecords()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var records = cnn.Query<SystemUserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();

                return records;
            }
        }


        public static List<SystemUserModel> ApplyFilter(string filter)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                var p = new
                {
                    Filter = filter
                };

                var records = cnn.Query<SystemUserModel>("spSystemUser_GetFiltered", p, commandType: CommandType.StoredProcedure).ToList();

                return records;
            }
        }
    }
}
