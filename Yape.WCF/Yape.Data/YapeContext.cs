using System.Data.Entity;
using Yape.Entities;

namespace Yape.Data
{
    /// <summary>
    /// Represents the database context for Yape, handling the connection to the database and managing entity sets.
    /// Inherits from <see cref="DbContext"/> provided by Entity Framework.
    /// </summary>
    public class YapeContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet for managing <see cref="Person"/> entities in the database.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="YapeContext"/> class with the specified connection string.
        /// </summary>
        /// <param name="connectionString">The connection string for accessing the database.</param>
        public YapeContext(string connectionString) : base(connectionString) // Database connection string
        {
        }
    }
}
