using System.Collections.Generic;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Process
{
    public abstract class BaseProcess<TEntity, TEntityList, TKey, TFlag> : IBaseProcess<TEntity, TEntityList, TKey, TFlag>
        where TEntity : IBaseDomain, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>

    {
        protected IBaseDal<TEntity, TEntityList, TKey> Provider { get; set; }

        protected BaseProcess(IBaseDal<TEntity, TEntityList, TKey> provider)
        {
            Provider = provider;
        }
        #region IDal<TEntity,TEntityList,TKey> Members
        public abstract TEntity Create(TEntity item);
        public abstract TEntity Get(TKey key, TFlag includeRemoved);
        public abstract TEntityList GetAll(TFlag includeRemoved);
        public abstract TEntity Save(TEntity item);
        public abstract TEntityList SaveAll(TEntityList items);
        public abstract IDomainStatus Remove(TKey key);
        #endregion
    }
}
