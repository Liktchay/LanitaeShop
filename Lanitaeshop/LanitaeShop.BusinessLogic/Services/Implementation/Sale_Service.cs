using System;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Sale;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;
using System.Threading.Tasks;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Sale_Service : ISale_Service
    {
        private ICRUD _crud = new CRUD();

        public async Task<ResultSet<Sale_ResultSet>> AddSale(int productID, int saleTotalAmout, int personID)
        {
            ResultSet<Sale_ResultSet> result = new ResultSet<Sale_ResultSet>();

            try
            {
                Sale newSale = new Sale()
                {
                    ID = productID,
                    SaleTotalAmount = saleTotalAmout,
                    PersonID = personID
                };

                newSale = await _crud.Create<Sale>(newSale);

                Sale_ResultSet addedSale = new Sale_ResultSet()
                {
                    id = newSale.ID,
                    productID = newSale.ProductID,
                    saleTotalAmount = newSale.SaleTotalAmount,
                    personID = newSale.PersonID,
                    saleDateTime = newSale.SaleDate
                };

                result.userMessage = string.Format("New sale has been added. Ticket ID {0}", addedSale.id);
                result.internalMessage = "BusinessLogic.Services.Implementation.Sale_Service: AddSale() method executed successfuly.";
                result.result_set = addedSale;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = "Fail to add sale.";
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Sale_Service: AddSale() {0}", exception);
                result.exception = exception;
            }

            return result;
        }
    }
}
