using Microsoft.AspNetCore.Http;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.WebAPI.Models.GetProductsResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanitaeShop.WebAPI.Controller
{
    [Route("spexecution")]
    [ApiController]
    public class SPExecutionController : ControllerBase
    {

        private ISPExecution_Service _spExecution_Service;

        public SPExecutionController(ISPExecution_Service spExecution_Service)
        {
            _spExecution_Service = spExecution_Service;
        }

        [HttpPost]
        [Route("execute")]
        public async Task<IActionResult> GetProducts(string spName, string param, string value)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();           
            parameters.Add(new SqlParameter(param, value));

            var result = _spExecution_Service.ExecuteSp<GetProductResult>(spName,parameters);

            if (result.success)
                return Ok(result);
            else
                return StatusCode(500, result);
        }










    }
}
