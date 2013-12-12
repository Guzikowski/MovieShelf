using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Interface.Process
{
    
    public interface IBaseEntityProcess<TEntity, TEntityList, in TKey, in TFlag> : IBaseProcess<TEntity, TEntityList, TKey, TFlag>
        where TEntity : IBaseEntity, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
    }
}
