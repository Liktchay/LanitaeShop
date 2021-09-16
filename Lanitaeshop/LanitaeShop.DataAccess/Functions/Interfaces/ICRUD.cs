using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanitaeShop.DataAccess.Functions.Interfaces
{
    public interface ICRUD
    {
        Task<T> Create<T>(T dbObject) where T : class;

        Task<T> Select<T>(int id) where T : class;

        Task<T> Update<T>(T dbObject, int id) where T : class;

        Task<bool> Delete<T>(int id) where T : class;

    }
}
