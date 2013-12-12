using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class DisplayImageProcess : BaseProcess<DisplayImage, IDomainList<DisplayImage, IEnumerable<DisplayImage>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public DisplayImageProcess(IBaseDal<DisplayImage, IDomainList<DisplayImage, IEnumerable<DisplayImage>>, int> provider)
            : base(provider)
        {
        }

        public override DisplayImage Create(DisplayImage item)
        {
            return item.IsNew && item.Validate() ? Provider.Add(item) : item;
        }

        public override DisplayImage Get(int key, bool includeRemoved)
        {
            var result = Provider.Read(key);
            if (includeRemoved)
            {
                return result;
            }
            return result.IsRemoved ? default(DisplayImage) : result;
        }

        public override IDomainList<DisplayImage, IEnumerable<DisplayImage>> GetAll(bool includeRemoved)
        {
            var result = Provider.ReadAll();
            if (includeRemoved)
            {
                result.Validate();
                return result;
            }
            result.EntityList = result.EntityList.ToList().Select(x => x.IsRemoved) as IEnumerable<DisplayImage>;
            result.Validate();
            return result;
        }

        public override DisplayImage Save(DisplayImage item)
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
        public override IDomainList<DisplayImage, IEnumerable<DisplayImage>> SaveAll(IDomainList<DisplayImage, IEnumerable<DisplayImage>> items)
        {
            items.EntityList = items.EntityList.Select(Save).ToList();
            items.Validate();
            return items;
        }
        public override IDomainStatus Remove(int key)
        {
            return Provider.Delete(key);
        }
        #endregion

    }
}
