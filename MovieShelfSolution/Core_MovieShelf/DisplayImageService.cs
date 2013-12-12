using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class DisplayImageService : BaseService<DisplayImage, IDomainList<DisplayImage, IEnumerable<DisplayImage>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public DisplayImageService(
            IBaseProcess<DisplayImage, IDomainList<DisplayImage, IEnumerable<DisplayImage>>, int, bool> process)
            : base(process)
        {
        }

        public override DisplayImage Create(DisplayImage item)
        {
            return Process.Create(item);
        }

        public override DisplayImage Get(int key, bool includeRemoved)
        {
            return Process.Get(key,includeRemoved);
        }

        public override IDomainList<DisplayImage, IEnumerable<DisplayImage>> GetAll(bool includeRemoved)
        {
            return Process.GetAll(includeRemoved);
        }

        public override DisplayImage Save(DisplayImage item)
        {
            return Process.Save(item);
        }
        public override IDomainList<DisplayImage, IEnumerable<DisplayImage>> SaveAll(IDomainList<DisplayImage, IEnumerable<DisplayImage>> items)
        {
            return Process.SaveAll(items);
        }
        public override IDomainStatus Remove(int key)
        {
            return Process.Remove(key);
        }
        #endregion

    }
}
