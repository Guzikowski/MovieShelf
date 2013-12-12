using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Interface.Data
{
   public interface IBaseDal<TEntity, out TEntityList, in TKey>
        where TEntity : IBaseDomain, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
   {
        /// <summary>
        /// Adds a new entity to the persistence storage
        /// </summary>
        /// <param name="item">The entity instance to add</param>
        /// <returns>The entity that has just been added</returns>
        TEntity Add(TEntity item);
        /// <summary>
        /// Reads an entity instance from the persistence storage
        /// </summary>
        /// <param name="key">The key to extract the entity instance</param>
        /// <returns>The entity instance if it exists</returns>
        TEntity Read(TKey key);
        /// <summary>
        /// Reads all the available entity instances from the persistence storage
        /// </summary>
        /// <returns>The list of existing entities</returns>
        /// <remarks>In a real scenario, there could be a filtering condition,
        /// eventually expressed using a LINQ query expression</remarks>
        TEntityList ReadAll();
        /// <summary>
        /// Updates an entity in the persistence storage
        /// </summary>
        /// <param name="item">The entity instance to update</param>
        /// <returns>The entity that has just been updated</returns>
        TEntity Update(TEntity item);
        /// <summary>
        /// Deletes an entity from the persistence storage
        /// </summary>
        /// <param name="key">The entity to delete</param>
        /// <returns>The result of the deleting operation</returns>
        IDomainStatus Delete(TKey key);
        IDomainStatus InUse(TKey key);
    }
}
