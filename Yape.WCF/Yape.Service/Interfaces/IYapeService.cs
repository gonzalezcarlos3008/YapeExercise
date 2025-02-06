using System.Collections.Generic;
using System.ServiceModel;
using Yape.Business.Entities;

namespace Yape.Business.Interfaces
{
    /// <summary>
    /// Defines the service contract for Yape-specific operations.
    /// This interface is used to expose methods via WCF (Windows Communication Foundation).
    /// </summary>
    [ServiceContract]
    public interface IYapeService
    {
        /// <summary>
        /// Retrieves a list of persons associated with the specified cell phone number using XML serialization format.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="PersonEntity"/> objects that match the provided cell phone number.</returns>
        [OperationContract]
        [XmlSerializerFormat]
        List<PersonEntity> GetPersonByCellPhone(long cellPhoneNumber);
    }
}
