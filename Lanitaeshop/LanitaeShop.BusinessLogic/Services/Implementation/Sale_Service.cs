using System;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using System.Threading.Tasks;
using LanitaeShop.DomainModel;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Sale_Service : ISale_Service
    {
        private ICRUD<Sale> _crud = new CRUD<Sale>();

        public async Task<ResultSet<Sale>> AddSale(int productID, int saleTotalAmout, int personID)
        {
            ResultSet<Sale> result = new ResultSet<Sale>();

            try
            {
                Sale newSale = new Sale()
                {
                    ProductID = productID,
                    SaleTotalAmount = saleTotalAmout,
                    PersonID = personID
                };

                newSale = await _crud.Create(newSale);

                Sale addedSale = new Sale()
                {
                    ProductID = newSale.ProductID,
                    SaleTotalAmount = newSale.SaleTotalAmount,
                    PersonID = newSale.PersonID,
                    SaleDate = newSale.SaleDate
                };

                result.userMessage = string.Format("New sale has been added. Ticket ID {0}", addedSale.ID);
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
