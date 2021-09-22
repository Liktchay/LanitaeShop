using System;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Product;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Product_Service : IProduct_Service
    {
        private ICRUD _crud = new CRUD();
        public async Task<ResultSet<Product_ResultSet>> AddProduct(string productName, string productDescription, int productPrice, int productStock, bool productEnable)
        {
            ResultSet<Product_ResultSet> result = new ResultSet<Product_ResultSet>();

            try
            {
                Product newProduct = new Product
                {
                    ProductName = productName,
                    ProductDescription = productDescription,
                    ProductPrice = productPrice,
                    ProductStock = productStock,
                    ProductEnable = productEnable
                };

                newProduct = await _crud.Create<Product>(newProduct);

                Product_ResultSet addedProduct = new Product_ResultSet
                {
                    id = newProduct.ID,
                    productName = newProduct.ProductName,
                    productDescription = newProduct.ProductDescription,
                    productPrice = newProduct.ProductPrice,
                    productStock = newProduct.ProductStock,
                    productEnable = newProduct.ProductEnable
                };

                result.userMessage = string.Format("The product {0} has been added", productName);
                result.internalMessage = "BusinessLogic.Services.Implementation.Product_Service: AddProduct() method executed successfuly.";
                result.result_set = addedProduct;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "Fail to add the new product.";
                result.exception = exception;
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Product_Service: AddProduct() {0}", exception.Message);
            }

            return result;
        }

        public async Task<ResultSet<Product_ResultSet>> GetProduct(int id)
        {
            ResultSet<Product_ResultSet> result = new ResultSet<Product_ResultSet>();

            try
            {
                Product Product = await _crud.Select<Product>(id);

                Product_ResultSet productFind = new Product_ResultSet
                {
                    id = Product.ID,
                    productName = Product.ProductName,
                    productDescription = Product.ProductDescription,
                    productPrice = Product.ProductPrice,
                    productStock = Product.ProductStock,
                    productEnable = Product.ProductEnable
                };

                result.userMessage = string.Format("Product with ID {0} was found", id);
                result.internalMessage = "BusinessLogic.Services.Implementation.Product_Service: GetProduct() method executed successfuly.";
                result.result_set = productFind;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = string.Format("Fail to get product with ID {0}", id);
                result.exception = exception;
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Product_Service: GetProduct() {0}", exception.Message);
            }

            return result;
        }

        public async Task<ResultSet<Product_ResultSet>> UpdateProduct(int id, string productName, string productDescription, int? productPrice, int? productStock, bool? productEnable)
        {
            ResultSet<Product_ResultSet> result = new ResultSet<Product_ResultSet>();

            try
            {
                Product Product = await _crud.Select<Product>(id);

                Product.ProductName = !string.IsNullOrEmpty(productName) ? productName : Product.ProductName;
                Product.ProductDescription = !string.IsNullOrEmpty(productDescription) ? productDescription : Product.ProductDescription;
                Product.ProductPrice = productPrice != null  ? productPrice : Product.ProductPrice;
                Product.ProductStock = productStock != null ? productStock : Product.ProductStock;
                Product.ProductEnable = productEnable != null ? productEnable : Product.ProductEnable;


                Product = await _crud.Update<Product>(Product, id);

                Product_ResultSet updatedProduct = new Product_ResultSet
                {
                    id = Product.ID,
                    productName = Product.ProductName,
                    productDescription = Product.ProductDescription,
                    productPrice = Product.ProductPrice,
                    productStock = Product.ProductStock,
                    productEnable = Product.ProductEnable
                };

                result.userMessage = string.Format("The product with ID {0} has been successfuly updated", id);
                result.internalMessage = "BusinessLogic.Services.Implementation.Product_Service: UpdateProduct() method executed successfuly.";
                result.result_set = updatedProduct;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = string.Format("Failed to update product with ID {0}", id);
                result.exception = exception;
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Product_Service: UpdateProduct() {0}.", exception.Message);
            }

            return result;
        }
    }
}
