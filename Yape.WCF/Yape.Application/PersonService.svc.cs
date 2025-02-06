using System.Collections.Generic;
using Yape.Business.Entities;
using Yape.Business.Services;
using Yape.Bussines.Repositories;

namespace Yape.Application
{
    /// <summary>
    /// Implements the <see cref="IPersonService"/> interface to provide operations related to Person entities.
    /// This class handles the business logic for retrieving person information from the data repository.
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Retrieves a list of persons associated with the specified cell phone number.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="PersonEntity"/> objects matching the provided cell phone number.</returns>
        public List<PersonEntity> GetPersonsByCellPhone(long cellPhoneNumber)
        {
            YapeService service = new YapeService(new PersonRepository("name=YapeContext"));
            return service.GetPersonByCellPhone(cellPhoneNumber);
        }
    }
}
