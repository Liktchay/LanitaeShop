using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Person;

namespace LanitaeShop.BusinessLogic.Services.Interfaces
{
    public interface IPerson_Service
    {
        Task<ResultSet<Person_ResultSet>> AddPerson(string personName, string personSurname, string personAddress);
        Task<ResultSet<Person_ResultSet>> GetPerson(int id);
        Task<ResultSet<Person_ResultSet>> UpdatePerson(int id, string personAddress);
    }
}
