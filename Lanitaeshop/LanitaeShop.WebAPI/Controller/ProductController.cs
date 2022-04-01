using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.Models.Product;
using Microsoft.AspNetCore.Cors;
using LanitaeShop.DomainModel;
using Newtonsoft.Json;
using System.Text.Json;

namespace LanitaeShop.Controller
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProduct_Service _product_Service;

        public ProductController(IProduct_Service product_Service)
        {
            _product_Service = product_Service;
        }

        [HttpPost]
        [Route("addproduct")]
        public async Task<IActionResult> AddProduct(Product product) 
        {           
            var result = await _product_Service.AddProduct(product.ProductName, product.ProductDescription, product.ProductPrice, product.ProductStock, product.ProductEnable, product.ImageSource);//product.garment, product.price);
            


            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        
        [Route("getproduct")]
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


        [HttpGet]
        [Route("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _product_Service.GetAllProducts();

            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("updateproduct")]
        public async Task<IActionResult> UpdateProduct(int id, string name, string description, int price, int stock, bool enable)
        {
            var result = await _product_Service.UpdateProduct(id, name, description, price, stock, enable);

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
