using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.Models.Product;

namespace LanitaeShop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _product_Service;

        public ProductController(IProduct_Service product_Service)
        {
            _product_Service = product_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddProduct(Product_Pass_Object product)
        {
            var result = await _product_Service.AddProduct(product.garment, product.price);

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
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _product_Service.GetProduct(id);

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
        public async Task<IActionResult> UpdateProduct(ProductUpdate_Pass_Object product)
        {
            var result = await _product_Service.UpdateProduct(product.id, product.garment, product.price);

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
