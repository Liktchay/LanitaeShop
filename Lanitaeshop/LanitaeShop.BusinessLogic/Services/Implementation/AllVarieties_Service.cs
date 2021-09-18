using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.DataAccess.Functions.SP;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class AllVarieties_Service : IAllVarieties_Service
    {
        internal AllVarieties _allVarieties = new AllVarieties();
        public ResultSet_List<AllVarietiesResult_ResultSet> callsp(int id)
        {
            ResultSet_List<AllVarietiesResult_ResultSet> result = new ResultSet_List<AllVarietiesResult_ResultSet>();

            try
            {
                List<AllVarietiesResult> pepe = _allVarieties.Callsp<AllVarietiesResult>(id);

                List<AllVarietiesResult_ResultSet> newList = new List<AllVarietiesResult_ResultSet>();

                

                foreach (var item in pepe)
                {
                    AllVarietiesResult_ResultSet jose = new AllVarietiesResult_ResultSet();

                    jose.garment = item.Garment;
                    jose.price = item.Price;
                    jose.productDescription = item.ProductDescription;
                    jose.color = item.Color;
                    jose.stock = item.Stock;

                    newList.Add(jose);
                }

                result.userMessage = "All varieties recovered successful.";
                result.internalMessage = "BusinessLogic.Services.Implementation.AllVarieties: callsp() method executed successfuly.";
                result.result_set = newList;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.userMessage = "SE ROMPIO TODO";
                result.internalMessage = string.Format("ANDA A SABER QUE PASO {0}", exception);
                result.exception = exception;
            }

            return result;
        }

    }
}
