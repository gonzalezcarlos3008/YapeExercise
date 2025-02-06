using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Yape.Bussines.Interfaces;
using Yape.Data;

namespace Yape.Bussines.Repositories
{
    /// <summary>
    /// Implementation of a generic repository.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by the repository.</typeparam>
    /// <summary>
    /// Generic repository class for performing basic CRUD operations on entities of type <typeparamref name="T"/>.
    /// Implements the <see cref="IRepository{T}"/> interface to provide data access functionality.
    /// </summary>
    /// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Retrieves all entities of type <typeparamref name="T"/> from the data store.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var _context = new YapeContext(this._connectionString))
            {
                return await _context.Set<T>().ToListAsync();
            }
        }

        /// <summary>
        /// Retrieves an entity by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier, or <c>null</c> if not found.</returns>
        public async Task<T> GetByIdAsync(long id)
        {
            using (var _context = new YapeContext(this._connectionString))
            {
                return await _context.Set<T>().FindAsync(id);
            }
        }

        /// <summary>
        /// Adds a new entity to the data store.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        public async Task AddAsync(T entity)
        {
            using (var _context = new YapeContext(this._connectionString))
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates an existing entity in the data store.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public async Task UpdateAsync(T entity)
        {
            using (var _context = new YapeContext(this._connectionString))
            {
                _context.Set<T>().AddOrUpdate(entity);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes an entity from the data store by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity to delete.</param>
        public async Task DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                using (var _context = new YapeContext(this._connectionString))
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
