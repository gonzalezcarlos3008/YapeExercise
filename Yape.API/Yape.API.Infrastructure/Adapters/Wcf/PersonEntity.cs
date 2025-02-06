using System.ComponentModel;
using System.Runtime.Serialization;

namespace Yape.API.Infrastructure.Adapters.Wcf
{
    [DataContract(Name = "PersonEntity", Namespace = "http://schemas.datacontract.org/2004/07/Yape.Business.Entities")]
    public class PersonEntity : object, IExtensibleDataObject, INotifyPropertyChanged
    {
        [DataMember]
        public long cellPhoneNumber { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string DocumentType { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }

        [Browsable(false)]
        public ExtensionDataObject ExtensionData { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
