using System;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DomainModel;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Person_Service : IPerson_Service
    {
        private ICRUD<Person> _crud = new CRUD<Person>();
        public async Task<ResultSet<Person>> AddPerson(string personName, string personSurname, string personAddress)
        {
            ResultSet<Person> result = new ResultSet<Person>();

            try
            {
                Person newPerson = new Person()
                {
                    PersonName = personName,
                    PersonSurname = personSurname,
                    PersonAddress = personAddress
                };

                newPerson = await _crud.Create(newPerson);

                Person addedPerson = new Person()
                {
                    ID = newPerson.ID,
                    PersonName = newPerson.PersonName,
                    PersonSurname = newPerson.PersonSurname,
                    PersonAddress = newPerson.PersonAddress
                };

                result.userMessage = string.Format("The person {0} has been added", personName);
                result.internalMessage = "BusinessLogic.Services.Implementation.Person_Service: AddPerson() method executed successfuly.";
                result.result_set = addedPerson;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.userMessage = "Fail to add the new person.";
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Person_Service: AddPerson() {0}", exception);
                result.exception = exception;
            }

            return result;
        }

        public async Task<ResultSet<Person>> GetPerson(int id)
        {
            ResultSet<Person> result = new ResultSet<Person>();

            try
            {
                Person person = await _crud.Select(id);

                Person foundProduct = new Person()
                {
                    ID = person.ID,
                    PersonName = person.PersonName,
                    PersonSurname = person.PersonSurname,
                    PersonAddress = person.PersonAddress
                };

                result.userMessage = string.Format("The person with {0} was found.", id);
                result.internalMessage = "BusinessLogic.Services.Implementation.Person_Service: GetPerson() method executed successfuly.";
                result.result_set = foundProduct;
                result.success = true;
            }
            catch(Exception exception)
            {
                result.userMessage = string.Format("Error getting person with ID {0}", id);
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Person_Service: GetPerson() {0}", exception);
                result.exception = exception;
            }
            return result;
        }

        public async Task<ResultSet<Person>> UpdatePerson(int id, string personAddress)
        {
            ResultSet<Person> result = new ResultSet<Person>();

            try
            {
                Person updatePerson = await _crud.Select(id);

                updatePerson.PersonAddress = !string.IsNullOrEmpty(personAddress) ? personAddress : updatePerson.PersonAddress;

                updatePerson = await _crud.Update(updatePerson, id);

                Person personUpdated = new Person()
                {
                    ID = updatePerson.ID,
                    PersonName = updatePerson.PersonName,
                    PersonSurname = updatePerson.PersonSurname,
                    PersonAddress = updatePerson.PersonAddress
                };

                result.userMessage = string.Format("The person {0} address has been udpated", personUpdated.PersonName);
                result.internalMessage = "BusinessLogic.Services.Implementation.Person_Service: UpdatePerson() method executed successfuly.";
                result.result_set = personUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                result.userMessage = string.Format("Fail to update address of person with ID {0}", id);
                result.internalMessage = string.Format("BusinessLogic.Services.Implementation.Person_Service: UpdatePerson() {0}", exception);
                result.exception = exception;
            }

            return result;
        }
    }
}
