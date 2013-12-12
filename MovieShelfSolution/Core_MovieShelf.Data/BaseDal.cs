using System.Collections.Generic;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{
    public abstract class BaseDal<TEntity, TEntityList, TKey> 
        : IBaseDal<TEntity, TEntityList, TKey>
        where TEntity : IBaseDomain, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>

    {
        protected MovieShelfEntities MovieShelfContext { get; private set; }
        //protected BaseDal()
        //{
        //    MovieShelfContext = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString);
        //}
        protected BaseDal(MovieShelfEntities context)
        {
            MovieShelfContext = context;
        }
        #region IDal<TEntity,TEntityList,TKey> Members
        public abstract TEntity Add(TEntity item);
        public abstract TEntity Read(TKey key);
        public abstract TEntityList ReadAll();
        public abstract TEntity Update(TEntity item);
        public abstract IDomainStatus Delete(TKey key);
        public abstract IDomainStatus InUse(TKey key);

        #endregion
    }
}
