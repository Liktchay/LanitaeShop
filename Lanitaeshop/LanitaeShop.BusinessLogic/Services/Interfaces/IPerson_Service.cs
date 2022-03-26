using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Person;
using LanitaeShop.DomainModel;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IPerson_Service
    {
        Task<ResultSet<Person>> AddPerson(string personName, string personSurname, string personAddress);
        Task<ResultSet<Person>> GetPerson(int id);
        Task<ResultSet<Person>> UpdatePerson(int id, string personAddress);
    }
}
