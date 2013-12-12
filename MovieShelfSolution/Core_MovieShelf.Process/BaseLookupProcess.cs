using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Process
{
    public class BaseLookupProcess<TEntity, TEntityList, TKey, TFlag> : BaseProcess<TEntity, TEntityList, TKey, TFlag>, IBaseLookupProcess<TEntity, TEntityList, TKey, TFlag>
        where TEntity : BaseLookup, new()
        where TEntityList : IDomainList<TEntity, IEnumerable<TEntity>>
    {
        
        #region IDal<TEntity,TEntityList,TKey> Members

        public BaseLookupProcess(IBaseDal<TEntity, TEntityList, TKey> provider) : base(provider)
        {
        }

        public override TEntity Create(TEntity item)
        {
            return item.IsNew && item.Validate() ? Provider.Add(item) : item;
        }

        public override TEntity Get(TKey key, TFlag includeRemoved)
        {
            var result = Provider.Read(key);
            if (includeRemoved is bool ? Convert.ToBoolean(includeRemoved) : false)
            {
                return result;
            }
            if ((result.Id > 0) && (!result.IsRemoved))
            {
                return result;
            }
            result = new TEntity();
            result.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
            return result;
        }

        public override TEntityList GetAll(TFlag includeRemoved)
        {
            var result = Provider.ReadAll();
            if (includeRemoved is bool ? Convert.ToBoolean(includeRemoved) : false)
            {
                result.Validate();
                return result;
            }
            result.EntityList = result.EntityList.ToList().Select(x => x.IsRemoved) as IEnumerable<TEntity>;
            result.Validate();
            return result;
        }

        public override TEntity Save(TEntity item)
        {
            if (!item.Validate())
            {
                return item;
            }
            if (item.IsNew)
            {
                return Provider.Add(item);
            }
            if ((item.IsRemoved) || (item.HasChanged))
            {
                return Provider.Update(item);
            }
            return item;
        }
        public override TEntityList SaveAll(TEntityList items)
        {
            items.EntityList = items.EntityList.Select(Save).ToList();
            items.Validate();
            return items; 
        }
        public override IDomainStatus Remove(TKey key)
        {
            return Provider.Delete(key);
        }
        #endregion
    }
}
