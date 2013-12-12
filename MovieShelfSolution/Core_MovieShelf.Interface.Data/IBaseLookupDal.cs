using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Interface.Data
{
    public interface IBaseLookupDal<TEntity, out TEntityList, in TKey> : IBaseDal<TEntity, TEntityList, TKey>
        where TEntity : IBaseLookup, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
    }
}
