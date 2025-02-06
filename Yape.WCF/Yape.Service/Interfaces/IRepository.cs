using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yape.Bussines.Interfaces
{
    /// <summary>
    /// Defines a generic repository interface for performing basic CRUD operations on entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the entity that the repository manages. Must be a reference type.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/>.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        Task<T> GetByIdAsync(long id);

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Updates an existing entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        Task DeleteAsync(long id);
    }
}
