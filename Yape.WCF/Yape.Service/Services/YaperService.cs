using System.Collections.Generic;
using System.Linq;
using Yape.Bussines.Repositories;
using Yape.Business.Interfaces;
using Yape.Business.Entities;

namespace Yape.Business.Services
{
    /// <summary>
    /// Service class for managing operations related to Yape.
    /// Implements the <see cref="IYapeService"/> interface to handle business logic for retrieving person information.
    /// </summary>
    public class YapeService : IYapeService
    {
        private readonly PersonRepository _repository; // Dependency Injection

        /// <summary>
        /// Initializes a new instance of the <see cref="YapeService"/> class with the specified repository.
        /// </summary>
        /// <param name="repository">The repository used to access person data.</param>
        public YapeService(PersonRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a list of <see cref="PersonEntity"/> objects based on the provided cell phone number.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="PersonEntity"/> objects matching the provided cell phone number.</returns>
        public List<PersonEntity> GetPersonByCellPhone(long cellPhoneNumber)
        {
            var persons = _repository.GetPersonsByCellPhone(cellPhoneNumber);
            if (persons != null && persons.Any())
            {
                return persons.Select(person => new PersonEntity
                {
                    cellPhoneNumber = person.CellPhoneNumber,
                    Name = person.Name,
                    LastName = person.LastName,
                    DocumentType = person.DocumentType,
                    DocumentNumber = person.DocumentNumber
                }).ToList();
            }
            return new List<PersonEntity>();
        }
    }
}
