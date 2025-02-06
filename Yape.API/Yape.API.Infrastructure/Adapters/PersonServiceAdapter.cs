using System.ServiceModel;
using Yape.API.Domain.Interfaces;
using Yape.API.Infrastructure.Adapters.Wcf;
using Yape.API.Infrastructure.Logging;

namespace Yape.API.Infrastructure.Adapters
{
    /// <summary>
    /// Adapter class that integrates with the WCF Person Service to validate customer information.
    /// Implements the <see cref="IValidationService"/> interface to perform validation checks.
    /// </summary>
    public class PersonServiceAdapter : IValidationService
    {
        private readonly IPersonService _personServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonServiceAdapter"/> class.
        /// Configures the WCF client with basic HTTP binding to connect to the external PersonService.
        /// </summary>
        public PersonServiceAdapter()
        {
            // WCF client configuration
            var binding = new BasicHttpBinding
            {
                Security = new BasicHttpSecurity { Mode = BasicHttpSecurityMode.None },
                MaxReceivedMessageSize = int.MaxValue,
            };

            var endpoint = new EndpointAddress("http://localhost:52329/PersonService.svc");
            var channelFactory = new ChannelFactory<IPersonService>(binding, endpoint);

            _personServiceClient = channelFactory.CreateChannel();
        }

        /// <summary>
        /// Validates customer information by querying the WCF service with the provided document type, document number, and phone number.
        /// </summary>
        /// <param name="documentType">The type of document (e.g., ID, Passport).</param>
        /// <param name="documentNumber">The document number associated with the customer.</param>
        /// <param name="cellPhoneNumber">The customer's cell phone number for verification.</param>
        /// <returns>
        /// Returns <c>true</c> if the customer exists with the provided information; otherwise, returns <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when no customer is found with the provided phone number.</exception>
        /// <exception cref="Exception">Thrown when an unexpected error occurs during the validation process.</exception>
        public bool Validate(string documentType, string documentNumber, long cellPhoneNumber)
        {
            try
            {
                // Calling the WCF service using the provided cell phone number
                var persons = _personServiceClient.GetPersonsByCellPhone(cellPhoneNumber);
                if (!persons.Any())
                {
                    throw new ArgumentException("Customer not found");
                }

                // Validating if any person matches the provided document type and document number
                var isValid = persons.Any(p => p.DocumentType == documentType && p.DocumentNumber == documentNumber);

                Logger.LogInfo($"Validation result for {documentType}-{documentNumber}: {isValid}");
                return isValid;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
