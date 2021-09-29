using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace LanitaeShop.DataAccess.Functions.Interfaces
{
    public interface IStoredProcedureExecution
    {
        List<T> SpExecution<T>(string storedProcedure, List<SqlParameter> paramObject) where T : class;
    }
}
