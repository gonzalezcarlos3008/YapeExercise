using Moq;
using Yape.API.Infrastructure.Adapters;
using Yape.API.Infrastructure.Adapters.Wcf;

namespace Yape.API.Tests.Infrastruture.Adapters
{
    public class PersonServiceAdapterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Validate_ReturnsTrue_WhenPersonExists()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonsByCellPhone(1234567890))
                       .Returns(new List<PersonEntity>
                       {
                           new PersonEntity { DocumentType = "ID", DocumentNumber = "123456" }
                       });

            var adapter = new PersonServiceAdapter();
            typeof(PersonServiceAdapter)
                .GetField("_personServiceClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(adapter, mockService.Object);

            // Act
            var result = adapter.Validate("ID", "123456", 1234567890);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void Validate_ReturnsException_WhenPersonDoesNotExist()
        {
            // Arrange
            var mockService = new Mock<IPersonService>();
            mockService.Setup(service => service.GetPersonsByCellPhone(1234567890))
                       .Returns(new List<PersonEntity>());

            var adapter = new PersonServiceAdapter();
            typeof(PersonServiceAdapter)
                .GetField("_personServiceClient", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(adapter, mockService.Object);

            // Assert
            Assert.Throws<ArgumentException>(() => adapter.Validate("ID", "999999", 1234567890));
        }
    }
}
