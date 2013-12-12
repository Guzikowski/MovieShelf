using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class ViewRatingTypeService : BaseLookupService<ViewRatingType, IDomainList<ViewRatingType, IEnumerable<ViewRatingType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public ViewRatingTypeService(
            IBaseProcess<ViewRatingType, IDomainList<ViewRatingType, IEnumerable<ViewRatingType>>, int, bool> process)
            : base(process)
        {
        }

        
        #endregion

    }
}
