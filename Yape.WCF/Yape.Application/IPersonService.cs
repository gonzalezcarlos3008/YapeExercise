using System.Collections.Generic;
using System.ServiceModel;
using Yape.Business.Entities;

namespace Yape.Application
{
    /// <summary>
    /// Defines the service contract for operations related to Person entities.
    /// This interface is used to expose methods via WCF (Windows Communication Foundation).
    /// </summary>
    [ServiceContract]
    public interface IPersonService
    {
        /// <summary>
        /// Retrieves a list of persons associated with the specified cell phone number.
        /// </summary>
        /// <param name="cellPhoneNumber">The cell phone number used to search for persons.</param>
        /// <returns>A list of <see cref="PersonEntity"/> objects that match the provided cell phone number.</returns>
        [OperationContract]
        List<PersonEntity> GetPersonsByCellPhone(long cellPhoneNumber);
    }

}
