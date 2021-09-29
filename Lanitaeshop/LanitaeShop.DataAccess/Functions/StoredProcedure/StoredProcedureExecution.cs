using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using LanitaeShop.DataAccess.DataContext;
using LanitaeShop.DataAccess.Functions.Interfaces;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace LanitaeShop.DataAccess.Functions.SP
{
    public class StoredProcedureExecution : IStoredProcedureExecution
    {
        public List<T> SpExecution<T>(string storedProcedure, List<SqlParameter> paramObject) where T : class
        {
            SqlConnection connection = CreateConnection();
            SqlCommand command = connection.CreateCommand();
            ReflectionPopulator<T> populator = new ReflectionPopulator<T>();
            List<T> result = new List<T>();


            using (connection)
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                foreach (var parameter in paramObject)
                {
                    command.Parameters.Add(parameter);
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                result = populator.CreateList(reader);
            }

            return result;
        }

        private SqlConnection CreateConnection()
        {
            AppConfiguration settings = new AppConfiguration();

            SqlConnection connection = new SqlConnection(settings.SqlConnectionString);

            return connection;
        }
    }
}