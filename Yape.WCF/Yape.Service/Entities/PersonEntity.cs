using System.Runtime.Serialization;

namespace Yape.Business.Entities
{
    /// <summary>
    /// Represents a person entity containing personal identification and contact information.
    /// This class is used for data transfer and serialization in WCF services.
    /// </summary>
    [DataContract]
    public class PersonEntity
    {
        /// <summary>
        /// Gets or sets the cell phone number of the person.
        /// </summary>
        [DataMember]
        public long cellPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the type of identification document (e.g., ID, Passport).
        /// </summary>
        [DataMember]
        public string DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the document number associated with the person.
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }
    }
}
