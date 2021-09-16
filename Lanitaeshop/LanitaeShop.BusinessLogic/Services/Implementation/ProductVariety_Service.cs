using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.ProductVariety;
using LanitaeShop.DataAccess.Entities;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Functions.CRUD;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class ProductVariety_Service : IProductVariety_Service
    {
        ICRUD _crud = new CRUD();

        public async Task<ResultSet<ProductVariety_ResultSet>> AddProductVariety(int productID, string productDescription, string color, int stock)
        {
            ResultSet<ProductVariety_ResultSet> result = new ResultSet<ProductVariety_ResultSet>();

            try
            {
                ProductVariety newProduct = new ProductVariety
                {
                    ProductID = productID,
                    ProductDescription = productDescription,
                    Color = color,
                    Stock = stock
                };

                newProduct = await _crud.Create<ProductVariety>(newProduct);

                ProductVariety_ResultSet addedProduct = new ProductVariety_ResultSet
                {
                    id = newProduct.ID,
                    productID = newProduct.ProductID,
                    productDescription = newProduct.ProductDescription,
                    color = newProduct.Color,
                    stock = newProduct.Stock
                };

                result.userMessage = string.Format("New product variety {0}-{1} has been added successfuly.", productDescription, color);
                result.internalMessage = "BusinessLogic.Services.Implementation.ProductVariety_Service: AddProductVariety() method executed successfuly.";
                result.result_set = addedProduct;
                result.success = true;

            }
            catch (Exception exception)
            {
                result.userMessage = string.Format("Fail to add product {0}.", productDescription);
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.ProductVariety_Service: AddProductVariety() {0}.", exception);
                result.exception = exception;
            }
            return result;
        }

        public async Task<ResultSet<ProductVariety_ResultSet>> UpdateProductVariety(int id, string productDescription, string color, int stock)
        {
            ResultSet<ProductVariety_ResultSet> result = new ResultSet<ProductVariety_ResultSet>();

            try
            {
                ProductVariety product = await _crud.Select<ProductVariety>(id);

                product.ProductDescription = productDescription != null ? productDescription : product.ProductDescription;
                product.Color = color != null ? color : product.Color;
                product.Stock = stock > 0 ? stock : product.Stock;

                product = await _crud.Update<ProductVariety>(product, product.ID);

                ProductVariety_ResultSet productUpdated = new ProductVariety_ResultSet
                {
                    id = product.ID,
                    productID = product.ProductID,
                    productDescription = product.ProductDescription,
                    color = product.Color,
                    stock = product.Stock,
                };

                result.userMessage = string.Format("The product with ID {0} has been successfuly updated", id);
                result.internalMessage = "BusinessLogic.Services.Implementation.ProductVariety_Service: UpdateProductVariety() method executed successfuly.";
                result.result_set = productUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "Fail to update product.";
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.ProductVariety_Service: UpdateProductVariety() {0} ", exception);
                result.exception = exception;
            }

            return result;
        }

        public async Task<ResultSet<ProductVariety_ResultSet>> GetProductVariety(int id)
        {
            ResultSet<ProductVariety_ResultSet> result = new ResultSet<ProductVariety_ResultSet>();

            try
            {
                ProductVariety product = await _crud.Select<ProductVariety>(id);

                ProductVariety_ResultSet productFind = new ProductVariety_ResultSet
                {
                    id = product.ID,
                    productID = product.ProductID,
                    productDescription = product.ProductDescription,
                    color = product.Color,
                    stock = product.Stock
                };

                result.userMessage = string.Format("The product variety with ID {0} has been found.", id);
                result.internalMessage = "BusinessLogic.Services.Implementation.ProductVariety_Service: GetProductVariety() method executed successfuly.";
                result.result_set = productFind;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "Fail to find product variety.";
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.ProductVariety_Service: GetProductVariety() {0}.", exception);
                result.exception = exception;
            }

            return result;
        }
    }
}

