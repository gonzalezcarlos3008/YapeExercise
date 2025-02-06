namespace Yape.API.Domain.Entities
{
    /// <summary>
    /// Represents a customer entity with personal and identification information.
    /// This class is used to store customer data in the system.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the customer.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the customer.
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer's cell phone number.
        /// </summary>
        public required long CellPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the type of document used for identification (e.g., ID, Passport).
        /// </summary>
        public required string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the customer's document number.
        /// </summary>
        public required string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the reason for creating the customer account.
        /// This field is optional.
        /// </summary>
        public string? ReasonOfUse { get; set; }
    }
}
