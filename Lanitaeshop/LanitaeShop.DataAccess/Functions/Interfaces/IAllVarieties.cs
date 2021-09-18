using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanitaeShop.DataAccess.Functions.Interfaces
{
    public interface IAllVarieties
    {
        List<T> callsp<T>(int id) where T : class;
    }
}
