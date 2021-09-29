using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Functions.SP;
using Microsoft.Data.SqlClient;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class SPExecution_Service : ISPExecution_Service
    {
        private IStoredProcedureExecution _spExecution = new StoredProcedureExecution();
        public ResultSet_List<T> ExecuteSp<T>(string spName, List<SqlParameter> parameters) where T : class
        {
            ResultSet_List<T> result = new ResultSet_List<T>();

            try
            {
                List<T> spResult = new List<T>();

                spResult = _spExecution.SpExecution<T>(spName, parameters);

                result.userMessage = "funciono";
                result.internalMessage = "vamo las putas";
                result.result_set = spResult;
                result.success = true;
    
            }
            catch(Exception exception)
            {
                result.userMessage = "se rompio todo";
                result.internalMessage = "cagamo";
                result.exception = exception;
            }

            return result;
        }

        
    }
}
