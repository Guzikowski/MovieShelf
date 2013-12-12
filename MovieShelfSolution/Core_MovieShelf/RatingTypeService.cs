using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class RatingTypeService : BaseLookupService<RatingType, IDomainList<RatingType, IEnumerable<RatingType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public RatingTypeService(
            IBaseProcess<RatingType, IDomainList<RatingType, IEnumerable<RatingType>>, int, bool> process)
            : base(process)
        {
        }
       
        #endregion

    }
}
