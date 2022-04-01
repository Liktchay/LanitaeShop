using System;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Product;
using LanitaeShop.DomainModel;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IProduct_Service
    {
        Task<ResultSet<Product>> AddProduct(string productName, string productDescription, int productPrice, int productStock, bool productEnable, string imageSource);

        Task<ResultSet<Product>> GetProduct(int id);

        Task<ResultSet_List<Product>> GetAllProducts();

        Task<ResultSet<Product>> UpdateProduct(int id, string productName, string productDescription, int productPrice, int productStock, bool productEnable);
    }
}
