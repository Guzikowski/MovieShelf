using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{
    
    public class BaseEntityService<TEntity, TEntityList, TKey, TFlag> : BaseService<TEntity, TEntityList, TKey, TFlag>, IBaseEntityProcess<TEntity, TEntityList, TKey, TFlag>
        where TEntity : BaseEntity, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public BaseEntityService(
            IBaseProcess<TEntity, TEntityList, TKey, TFlag> process) 
            : base(process)
        {
        }

        public override TEntity Create(TEntity item)
        {
            return Process.Create(item);
        }

        public override TEntity Get(TKey key, TFlag includeRemoved)
        {
            return Process.Get(key, includeRemoved);
        }

        public override TEntityList GetAll(TFlag includeRemoved)
        {
            return Process.GetAll(includeRemoved);
        }

        public override TEntity Save(TEntity item)
        {
            return Process.Save(item);
        }
        public override TEntityList SaveAll(TEntityList items)
        {
            return Process.SaveAll(items);
        }
        public override IDomainStatus Remove(TKey key)
        {
            return Process.Remove(key);
        }
        #endregion
    }
}
