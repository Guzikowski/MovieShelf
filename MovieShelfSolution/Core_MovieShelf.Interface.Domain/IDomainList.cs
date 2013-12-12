using System.Collections.Generic;

namespace Core_MovieShelf.Interface.Domain
{
    public interface IDomainList<TEntity, TEntityList>  
        where TEntity : IBaseDomain 
        where TEntityList : IEnumerable<TEntity>    
    {
        bool IsValid { get; }
        bool Validate();
        void Reset();
        TEntityList EntityList { get; set; }
        IDomainStatus DomainStatus { get; }
    }
}
