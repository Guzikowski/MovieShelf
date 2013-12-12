using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    [DataContract]
    public class DomainMessageContract : IDomainMessageContract
    {
        [DataMember]
        public EMessageType Type { get; set; }
        [DataMember]
        public EMessageNumber Id { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
