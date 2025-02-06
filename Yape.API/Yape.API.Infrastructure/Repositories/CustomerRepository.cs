using Yape.API.Domain.Entities;
using Yape.API.Domain.Interfaces;
using Yape.API.Infrastructure.Persistence;

namespace Yape.API.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class responsible for handling customer-related data operations in the database.
    /// Implements the <see cref="ICustomerRepository"/> interface to manage data persistence.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly YapeDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The <see cref="YapeDbContext"/> instance used to interact with the database.</param>
        public CustomerRepository(YapeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously adds a new customer to the database.
        /// </summary>
        /// <param name="customer">The <see cref="Customer"/> entity to be added to the database.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
    }
}
