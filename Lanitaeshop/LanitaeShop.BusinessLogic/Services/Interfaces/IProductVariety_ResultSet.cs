using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.ProductVariety;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IProductVariety_Service
    {
        Task<ResultSet<ProductVariety_ResultSet>> AddProductVariety(int productID, string productDescription, string color, int stock);

        Task<ResultSet<ProductVariety_ResultSet>> UpdateProductVariety(int id, string productDescription, string color, int stock);

        Task<ResultSet<ProductVariety_ResultSet>> GetProductVariety(int id);

    }
}
