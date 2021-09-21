using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using LanitaeShop.DataAccess.DataContext;
using System.Reflection;

namespace LanitaeShop.DataAccess.Functions.SP
{
    public class StoredProcedureExecution
    {

        public List<T> SpExecution<T>(string storedProcedure, T paramObject) where T : class
        {
            SqlConnection connection = CreateConnection();
            SqlCommand command = connection.CreateCommand();

            using (connection)
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = storedProcedure;
                foreach (var parameter in paramObject.GetType().GetProperties())
                {
                    command.Parameters.Add(new SqlParameter(parameter.Name, parameter.GetValue(paramObject, null)));
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {

                }

            }
        }

        private SqlConnection CreateConnection()
        {
            AppConfiguration settings = new AppConfiguration();

            SqlConnection connection = new SqlConnection(settings.SqlConnectionString);

            return connection;
        }

    }       
 }

