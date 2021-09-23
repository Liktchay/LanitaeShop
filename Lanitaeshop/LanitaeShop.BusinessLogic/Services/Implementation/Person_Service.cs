using System;
using System.Threading.Tasks;
using LanitaeShop.BusinessLogic.Services.Interfaces;
using LanitaeShop.BusinessLogic.Services.Models;
using LanitaeShop.BusinessLogic.Services.Models.Person;
using LanitaeShop.DataAccess.Functions.CRUD;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;

namespace LanitaeShop.BusinessLogic.Services.Implementation
{
    public class Person_Service : IPerson_Service
    {
        private ICRUD _crud = new CRUD();
        public async Task<ResultSet<Person_ResultSet>> AddPerson(string personName, string personSurname, string personAddress)
        {
            ResultSet<Person_ResultSet> result = new ResultSet<Person_ResultSet>();

            try
            {
                Person newPerson = new Person()
                {
                    PersonName = personName,
                    PersonSurname = personSurname,
                    PersonAddress = personAddress
                };

                newPerson = await _crud.Create<Person>(newPerson);

                Person_ResultSet addedPerson = new Person_ResultSet()
                {
                    id = newPerson.ID,
                    personName = newPerson.PersonName,
                    personSurname = newPerson.PersonSurname,
                    personAddress = newPerson.PersonAddress
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

        public async Task<ResultSet<Person_ResultSet>> GetPerson(int id)
        {
            ResultSet<Person_ResultSet> result = new ResultSet<Person_ResultSet>();

            try
            {
                Person person = await _crud.Select<Person>(id);

                Person_ResultSet foundProduct = new Person_ResultSet()
                {
                    id = person.ID,
                    personName = person.PersonName,
                    personSurname = person.PersonSurname,
                    personAddress = person.PersonAddress
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

        public async Task<ResultSet<Person_ResultSet>> UpdatePerson(int id, string personAddress)
        {
            ResultSet<Person_ResultSet> result = new ResultSet<Person_ResultSet>();

            try
            {
                Person updatePerson = await _crud.Select<Person>(id);

                updatePerson.PersonAddress = !string.IsNullOrEmpty(personAddress) ? personAddress : updatePerson.PersonAddress;

                updatePerson = await _crud.Update<Person>(updatePerson, id);

                Person_ResultSet personUpdated = new Person_ResultSet()
                {
                    id = updatePerson.ID,
                    personName = updatePerson.PersonName,
                    personSurname = updatePerson.PersonSurname,
                    personAddress = updatePerson.PersonAddress
                };

                result.userMessage = string.Format("The person {0} address has been udpated", personUpdated.personName);
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
