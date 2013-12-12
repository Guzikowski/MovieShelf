using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class ViewRatingTypeProcess : BaseLookupProcess<ViewRatingType, IDomainList<ViewRatingType, IEnumerable<ViewRatingType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public ViewRatingTypeProcess(IBaseDal<ViewRatingType, IDomainList<ViewRatingType, IEnumerable<ViewRatingType>>, int> provider)
            : base(provider)
        {
        }

        
        #endregion

    }
}
