using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IAllVarieties_Service
    {

        ResultSet_List<AllVarietiesResult_ResultSet> callsp(int id);

    }
}
