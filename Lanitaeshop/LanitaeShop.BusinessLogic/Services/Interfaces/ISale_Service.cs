using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Sale;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface ISale_Service
    {
        Task<ResultSet<Sale_ResultSet>> AddSale(int productID, int saleTotalAmout, int personID);
    }
}
