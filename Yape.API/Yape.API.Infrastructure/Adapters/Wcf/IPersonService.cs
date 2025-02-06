using System.ServiceModel;

namespace Yape.API.Infrastructure.Adapters.Wcf
{
    [ServiceContract(ConfigurationName = "PersonService.IPersonService")]
    public interface IPersonService
    {
        [OperationContract(Action = "http://tempuri.org/IPersonService/GetPersonsByCellPhone", ReplyAction = "http://tempuri.org/IPersonService/GetPersonsByCellPhoneResponse")]
        List<PersonEntity> GetPersonsByCellPhone(long cellPhoneNumber);
    }
}
