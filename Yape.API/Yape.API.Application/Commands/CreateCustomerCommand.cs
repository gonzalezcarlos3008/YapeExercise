namespace Yape.API.Application.Commands
{
    /// <summary>
    /// Represents the command to create a new customer in the system.
    /// This class holds the required data for customer creation.
    /// </summary>
    public class CreateCustomerCommand
    {
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
        /// Gets or sets the type of document (e.g., ID, Passport).
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
