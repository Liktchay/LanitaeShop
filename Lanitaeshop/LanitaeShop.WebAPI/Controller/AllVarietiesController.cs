using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;

namespace LanitaeShop.WebAPI.Controller
{
    [Route("api/allvarieties")]
    [ApiController]
    public class AllVarietiesController : ControllerBase
    {

        private IAllVarieties_Service _allVarieties_Service;

        public AllVarietiesController(IAllVarieties_Service allVarieties_Service)
        {
            _allVarieties_Service = allVarieties_Service;
        }


        [HttpGet]
        [Route("callsp")]
        public async Task<IActionResult> callsp(int id)
        {
            var result =  _allVarieties_Service.callsp(id);

            switch(result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }



    }
}
