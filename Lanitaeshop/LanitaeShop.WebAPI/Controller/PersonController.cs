using LanitaeShop.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanitaeShop.Controller
{
    [Route("person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPerson_Service _person_service;

        public PersonController(IPerson_Service person_service)
        {
            _person_service = person_service;
        }
        
        [HttpPost]
        [Route("addperson")]
        public async Task<IActionResult> AddPerson(string name, string surname, string address)
        {
            var result = await _person_service.AddPerson(name, surname, address);

            if (result.success)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpPost]
        [Route("getperson")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var result = await _person_service.GetPerson(id);
                
            if (result.success)
                return Ok(result);
            else
                return StatusCode(500, result);
        }

        [HttpPost]
        [Route("updateperson")]
        public async Task<IActionResult> UpdatePerson(int id, string address)
        {
            var result = await _person_service.UpdatePerson(id, address);

            if (result.success)
                return Ok(result);
            else
                return StatusCode(500, result);
        }
    }
}
