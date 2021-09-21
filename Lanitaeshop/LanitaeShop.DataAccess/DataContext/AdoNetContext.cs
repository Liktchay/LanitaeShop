using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LanitaeShop.DataAccess.DataContext
{
    public class AdoNetContext
    {

        public AdoNetContext()
        {
            Settings = new AppConfiguration();
            Connection = new SqlConnection(Settings.SqlConnectionString);
            Command = Connection.CreateCommand();
            Command.CommandType = CommandType.StoredProcedure;
        }

        private AppConfiguration Settings { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }




    }
}
