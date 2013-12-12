
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    [DataContract]
    public class DomainListContract<TEntityContract> : IDomainListContract<TEntityContract>
        where TEntityContract : IBaseDomainContract   
    {
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public List<TEntityContract> EntityList { get; set; }
        [DataMember]
        public DomainStatusContract DomainStatus { get; set; }
    }
}
