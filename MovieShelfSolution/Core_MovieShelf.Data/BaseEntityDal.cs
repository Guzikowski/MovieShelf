using System;
using System.Collections.Generic;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class BaseEntityDal<TEntity, TEntityList, TKey> 
        : BaseDal<TEntity, TEntityList, TKey>, IBaseEntityDal<TEntity, TEntityList, TKey>
        where TEntity : IBaseEntity, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
        protected BaseEntityDal(MovieShelfEntities context) 
            : base (context)
        {
            
        }
        #region IDal<TEntity,TEntityList,TKey> Members
        public override TEntity Add(TEntity item)
        {
            throw new NotImplementedException();
        }

        public override TEntity Read(TKey key)
        {
            throw new NotImplementedException();
        }

        public override TEntityList ReadAll()
        {
            throw new NotImplementedException();
        }

        public override TEntity Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public override IDomainStatus Delete(TKey key)
        {
            throw new NotImplementedException();
        }
        public override IDomainStatus InUse(TKey key)
        {
            throw new NotImplementedException();
        }
        #endregion

        
    }
}
