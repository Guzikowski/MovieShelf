using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Interface.Service
{
    
    public interface IBaseEntityService<TEntity, TEntityList, in TKey, in TFlag> : IBaseService<TEntity, TEntityList, TKey, TFlag>
        where TEntity : IBaseEntity, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
    }
}
