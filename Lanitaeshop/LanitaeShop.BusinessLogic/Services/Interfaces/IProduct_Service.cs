using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Product;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IProduct_Service
    {
        Task<ResultSet<Product_ResultSet>> AddProduct(string garment, float price);

        Task<ResultSet<Product_ResultSet>> GetProduct(int id);

        Task<ResultSet<Product_ResultSet>> UpdateProduct(int id, string garment, float price);
    }
}
