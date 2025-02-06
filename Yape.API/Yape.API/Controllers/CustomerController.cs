using Microsoft.AspNetCore.Mvc;
using Yape.API.Application.Commands;
using Yape.API.Application.Handlers;

namespace Yape.API.Controllers
{
    /// <summary>
    /// Controller responsible for managing customer-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="handler">Handler responsible for customer creation logic.</param>
        public CustomerController(CreateCustomerHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Creates a new customer based on the provided information.
        /// </summary>
        /// <param name="command">The customer creation request containing the required data.</param>
        /// <returns>
        /// Returns <see cref="IActionResult"/> with the newly created customer's ID if successful.
        /// </returns>
        /// <response code="200">Customer created successfully.</response>
        /// <response code="400">Bad request due to invalid input data.</response>
        /// <response code="500">Internal server error if something goes wrong during processing.</response>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var customerId = await _handler.Handle(command);
            return Ok(new { Id = customerId });
        }
    }
}
