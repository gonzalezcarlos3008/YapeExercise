using Microsoft.EntityFrameworkCore;
using Yape.API.Domain.Entities;

namespace Yape.API.Infrastructure.Persistence
{
    public class YapeDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> representing the Customers table in the database.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="YapeDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options">The options to be used by the <see cref="DbContext"/>, typically configured in the startup class.</param>
        public YapeDbContext(DbContextOptions<YapeDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Configures the model for the database context.
        /// Maps the <see cref="Customer"/> entity to the corresponding database table.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Maps the Customer entity to the "Customer" table in the database
            modelBuilder.Entity<Customer>().ToTable("Customer");
        }
    }
}
