﻿using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Sale;
using LanitaeShop.DomainModel;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface ISale_Service
    {
        Task<ResultSet<Sale>> AddSale(int productID, int saleTotalAmout, int personID);
    }
}
