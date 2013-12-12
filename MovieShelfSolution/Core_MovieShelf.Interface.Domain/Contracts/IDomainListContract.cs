using System.Collections.Generic;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    public interface IDomainListContract<TEntity>  
        where TEntity : IBaseDomainContract 
    {
        bool IsValid { get; set; }
        List<TEntity> EntityList { get; set; }
        DomainStatusContract DomainStatus { get; }
    }
}
