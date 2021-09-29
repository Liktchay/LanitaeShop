using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using LanitaeShop.BusinessLogic.Services.Models;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface ISPExecution_Service
    {
        ResultSet_List<T> ExecuteSp<T>(string spName, List<SqlParameter> parameters) where T : class;
    }
}
