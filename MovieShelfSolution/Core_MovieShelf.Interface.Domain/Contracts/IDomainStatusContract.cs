using System.Collections.Generic;

namespace Core_MovieShelf.Interface.Domain.Contracts
{

    
    public interface IDomainStatusContract
    {
        IList<DomainMessageContract> Messages { get; }
    }
}
