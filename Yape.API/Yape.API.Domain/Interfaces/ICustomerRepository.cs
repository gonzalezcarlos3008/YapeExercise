using Yape.API.Domain.Entities;

namespace Yape.API.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for customer data persistence operations.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Asynchronously adds a new customer to the data store.
        /// </summary>
        /// <param name="customer">The customer entity to be added.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Customer customer);
    }
}
