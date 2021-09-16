using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.Models.ProductVariety;

namespace LanitaeShop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVarietyController : ControllerBase
    {
        private IProductVariety_Service _productvariety_Service;

        public ProductVarietyController(IProductVariety_Service productvariety_service)
        {
            _productvariety_Service = productvariety_service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProductVariety(ProductVariety_Pass_Object product)
        {
            var result = await _productvariety_Service.AddProductVariety(product.productID, product.productDescription, product.color, product.stock);

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProductVariety(ProductVarietyUpdate_Pass_Object product)
        {
            var result = await _productvariety_Service.UpdateProductVariety(product.id, product.productDescription, product.color, product.stock);

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetProductVariety(int id)
        {
            var result = await _productvariety_Service.GetProductVariety(id);

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
