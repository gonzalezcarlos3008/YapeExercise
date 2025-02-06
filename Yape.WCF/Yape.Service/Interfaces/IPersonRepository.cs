
using System.Collections.Generic;
using Yape.Entities;

namespace Yape.Bussines.Interfaces
{
    /// <summary>
    /// Defines the repository contract for accessing and managing <see cref="Person"/> entities in the data store.
    /// Extends the generic <see cref="IRepository{T}"/> interface to include person-specific operations.
    /// </summary>
    internal interface IPersonRepository : IRepository<Person>
    {
        /// <summary>
        /// Retrieves a list of persons associated with the specified cell phone number.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="Person"/> entities that match the provided cell phone number.</returns>
        List<Person> GetPersonsByCellPhone(long cellPhoneNumber);
    }

}
