using Microsoft.AspNetCore.Mvc;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanitaeShop.Controller
{
    public class SaleController : ControllerBase
    {
        private ISale_Service _sale_service;

        public SaleController(ISale_Service sale_service)
        {
            _sale_service = sale_service;
        }

        [HttpPost]
        [Route("addsale")]
        public async Task<IActionResult> AddSale(int productid, int totalamout, int personid)
        {
            var result = await _sale_service.AddSale(productid, totalamout, personid);

            if (result.success)
                return Ok(result);
            else
                return StatusCode(500, result);
        }
    }
}
