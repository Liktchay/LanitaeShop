using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Product;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DomainModel;
using System.Linq;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Product_Service : IProduct_Service
    {
        private ICRUD<Product> _crud = new CRUD<Product>();
        public async Task<ResultSet<Product>> AddProduct(string productName, string productDescription, int productPrice, int productStock, bool productEnable)
        {
            ResultSet<Product> result = new ResultSet<Product>();

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

                newProduct = await _crud.Create(newProduct);

                Product addedProduct = new Product
                {
                    ID = newProduct.ID,
                    ProductName = newProduct.ProductName,
                    ProductDescription = newProduct.ProductDescription,
                    ProductPrice = newProduct.ProductPrice,
                    ProductStock = newProduct.ProductStock,
                    ProductEnable = newProduct.ProductEnable
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
        public async Task<ResultSet_List<Product>> GetAllProducts()
        {
            ResultSet_List<Product> result = new ResultSet_List<Product>();

            try
            {
                //Func<Product, bool> pepe = Product => true;

                

                IEnumerable<Product> pepito = await _crud.Select();

                

                result.userMessage = "FUNCO BIEN";
                result.internalMessage = "VAMO LAS PUTAS";
                result.result_set = pepito.ToList();
                result.success = true;
               

            }
            catch(Exception exception)
            {
                result.userMessage = "Fail to recover all products.";
                result.exception = exception;
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Product_Service: AddProduct() {0}", exception.Message);
            }

            return result;
        }
        public async Task<ResultSet<Product>> GetProduct(int id)
        {
            ResultSet<Product> result = new ResultSet<Product>();

            try
            {
                Product Product = await _crud.Select(id);

                Product productFind = new Product
                {
                    ID = Product.ID,
                    ProductName = Product.ProductName,
                    ProductDescription = Product.ProductDescription,
                    ProductPrice = Product.ProductPrice,
                    ProductStock = Product.ProductStock,
                    ProductEnable = Product.ProductEnable
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

        public async Task<ResultSet<Product>> UpdateProduct(int id, string productName, string productDescription, int? productPrice, int? productStock, bool? productEnable)
        {
            ResultSet<Product> result = new ResultSet<Product>();

            try
            {
                Product Product = await _crud.Select(id);

                Product.ProductName = !string.IsNullOrEmpty(productName) ? productName : Product.ProductName;
                Product.ProductDescription = !string.IsNullOrEmpty(productDescription) ? productDescription : Product.ProductDescription;
                Product.ProductPrice = productPrice != null  ? productPrice : Product.ProductPrice;
                Product.ProductStock = productStock != null ? productStock : Product.ProductStock;
                Product.ProductEnable = productEnable != null ? productEnable : Product.ProductEnable;


                Product = await _crud.Update(Product, id);

                Product updatedProduct = new Product
                {
                    ID = Product.ID,
                    ProductName = Product.ProductName,
                    ProductDescription = Product.ProductDescription,
                    ProductPrice = Product.ProductPrice,
                    ProductStock = Product.ProductStock,
                    ProductEnable = Product.ProductEnable
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
