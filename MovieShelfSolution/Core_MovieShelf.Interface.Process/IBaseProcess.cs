using System;
using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Interface.Process
{
   public interface IBaseProcess<TEntity, TEntityList, in TKey, in TFlag>
        where TEntity : IBaseDomain, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
        /// <summary>
        /// Adds a new entity to the persistence storage
        /// </summary>
        /// <param name="item">The entity instance to add</param>
        /// <returns>The entity that has just been added</returns>
        TEntity Create(TEntity item);

       /// <summary>
       /// Reads an entity instance from the persistence storage
       /// </summary>
       /// <param name="key">The key to extract the entity instance</param>
       /// <param name="includeRemoved"></param>
       /// <returns>The entity instance if it exists</returns>
        TEntity Get(TKey key, TFlag includeRemoved);
        /// <summary>
        /// Reads all the available entity instances from the persistence storage
        /// </summary>
        /// <returns>The list of existing entities</returns>
        /// <remarks>In a real scenario, there could be a filtering condition,
        /// eventually expressed using a LINQ query expression</remarks>
        TEntityList GetAll(TFlag includeRemoved);
        /// <summary>
        /// Updates an entity in the persistence storage
        /// </summary>
        /// <param name="item">The entity instance to update</param>
        /// <returns>The entity that has just been updated</returns>
        TEntity Save(TEntity item);
        TEntityList SaveAll(TEntityList items);
       /// <summary>
       /// Deletes an entity from the persistence storage
       /// </summary>
       /// <param name="key">The entity to delete</param>
       /// <returns>The result of the deleting operation</returns>
       IDomainStatus Remove(TKey key);
    }
}
