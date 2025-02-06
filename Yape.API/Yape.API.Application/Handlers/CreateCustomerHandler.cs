using Microsoft.EntityFrameworkCore;
using Yape.API.Application.Commands;
using Yape.API.Domain.Entities;
using Yape.API.Domain.Interfaces;
using Yape.API.Infrastructure.Logging;

namespace Yape.API.Application.Handlers
{
    /// <summary>
    /// Handles the business logic for creating a new customer.
    /// This class validates customer data and persists it in the repository.
    /// </summary>
    public class CreateCustomerHandler
    {
        private readonly IValidationService _validationService;
        private readonly ICustomerRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerHandler"/> class.
        /// </summary>
        /// <param name="validationService">Service responsible for validating customer information.</param>
        /// <param name="repository">Repository interface for customer data persistence.</param>
        public CreateCustomerHandler(IValidationService validationService, ICustomerRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        /// <summary>
        /// Handles the creation of a new customer.
        /// It validates the customer information and saves the data in the repository if valid.
        /// </summary>
        /// <param name="command">The command containing customer information to be processed.</param>
        /// <returns>Returns the unique identifier (<see cref="Guid"/>) of the newly created customer.</returns>
        /// <exception cref="ArgumentException">Thrown when the customer information fails validation.</exception>
        /// <exception cref="Exception">Thrown for any unexpected errors during processing.</exception>
        public async Task<Guid> Handle(CreateCustomerCommand command)
        {
            try
            {
                if (!_validationService.Validate(command.DocumentType, command.DocumentNumber, command.CellPhoneNumber))
                {
                    throw new ArgumentException("Customer information is incorrect");
                }

                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    LastName = command.LastName,
                    CellPhoneNumber = command.CellPhoneNumber,
                    DocumentType = command.DocumentType,
                    DocumentNumber = command.DocumentNumber,
                    ReasonOfUse = command.ReasonOfUse
                };

                await _repository.AddAsync(customer);
                Logger.LogInfo($"Customer created with ID: {customer.Id}");

                return customer.Id;
            }
            catch (DbUpdateException dbEx) when (dbEx.InnerException?.Message.Contains("UNIQUE KEY constraint") == true)
            {
                var errorMessage = "A customer with the same document number already exists.";
                Logger.LogError(new Exception(errorMessage, dbEx));
                throw new ArgumentException(errorMessage);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
