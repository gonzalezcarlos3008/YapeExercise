namespace Yape.API.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for validating customer information.
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Validates the customer's document and phone number information.
        /// </summary>
        /// <param name="documentType">The type of document used for identification (e.g., ID, Passport).</param>
        /// <param name="documentNumber">The unique document number associated with the customer.</param>
        /// <param name="cellPhoneNumber">The customer's cell phone number used for additional verification.</param>
        /// <returns>
        /// Returns <c>true</c> if the provided information is valid; otherwise, returns <c>false</c>.
        /// </returns>
        bool Validate(string documentType, string documentNumber, long cellPhoneNumber);
    }
}
