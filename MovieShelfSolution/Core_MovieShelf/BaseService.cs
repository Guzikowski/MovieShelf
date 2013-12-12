using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;
using Core_MovieShelf.Interface.Service;

namespace Core_MovieShelf.Service
{
    public abstract class BaseService<TEntity, TEntityList, TKey, TFlag> : IBaseService<TEntity, TEntityList, TKey, TFlag>
        where TEntity : IBaseDomain, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>

    {
        protected IBaseProcess<TEntity, TEntityList, TKey, TFlag> Process { get; set; }

        protected BaseService(IBaseProcess<TEntity, TEntityList, TKey, TFlag> process)
        {
            Process = process;
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
