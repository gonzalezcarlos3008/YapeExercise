using System.Collections.Generic;
using System.Linq;
using Yape.Bussines.Interfaces;
using Yape.Data;
using Yape.Entities;

namespace Yape.Bussines.Repositories
{
    /// <summary>
    /// Repository class for managing <see cref="Person"/> entities in the data store.
    /// Implements the <see cref="IPersonRepository"/> interface and extends the generic <see cref="Repository{T}"/> class.
    /// </summary>
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public PersonRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves a list of persons associated with the specified cell phone number.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="Person"/> entities matching the provided cell phone number.</returns>
        public List<Person> GetPersonsByCellPhone(long cellPhoneNumber)
        {
            using (var _context = new YapeContext(this._connectionString))
            {
                return _context.Persons
                   .Where(p => p.CellPhoneNumber == cellPhoneNumber).ToList();
            }
        }
    }
}
