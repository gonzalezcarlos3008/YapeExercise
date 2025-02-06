using Moq;
using Yape.API.Application.Commands;
using Yape.API.Application.Handlers;
using Yape.API.Domain.Entities;
using Yape.API.Domain.Interfaces;

namespace Yape.API.Tests.Application.Handlers
{
    public class CreateCustomerHandlerTests
    {
        private Mock<IValidationService> _mockValidationService;
        private Mock<ICustomerRepository> _mockRepository;
        private CreateCustomerHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockValidationService = new Mock<IValidationService>();
            _mockRepository = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerHandler(_mockValidationService.Object, _mockRepository.Object);
        }

        [Test]
        public async Task Handle_ShouldReturnCustomerId_WhenValidationSucceeds()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                Name = "John",
                LastName = "Doe",
                DocumentType = "ID",
                DocumentNumber = "123456",
                CellPhoneNumber = 9876543210,
                ReasonOfUse = "Testing"
            };

            _mockValidationService.Setup(v => v.Validate(command.DocumentType, command.DocumentNumber, command.CellPhoneNumber)).Returns(true);
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Customer>())).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command);

            // Assert
            Assert.True(result is Guid);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
        }
    }
}
