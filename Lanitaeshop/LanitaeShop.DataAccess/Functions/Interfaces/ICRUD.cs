using LanitaeShop.DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanitaeShop.DataAccess.Functions.Interfaces
{
    public interface ICRUD<T> where T : BaseEntity
    {
        Task<T> Create(T dbObject) ;

        Task<T> Select(int id) ;

        Task<IEnumerable<T>> Select(Func<T, bool> predicate = null) ;

        Task<T> Update(T dbObject, int id) ;

        Task<bool> Delete(int id) ;

    }
}
