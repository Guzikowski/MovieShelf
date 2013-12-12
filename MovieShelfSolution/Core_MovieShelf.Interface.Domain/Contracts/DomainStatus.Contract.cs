using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{

    [DataContract]
    public class DomainStatusContract : IDomainStatusContract
    {
        
        [DataMember]
        public IList<DomainMessageContract> Messages { get; set; }
    }
}
