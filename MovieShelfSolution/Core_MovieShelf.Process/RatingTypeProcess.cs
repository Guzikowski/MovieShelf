using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class RatingTypeProcess : BaseLookupProcess<RatingType, IDomainList<RatingType, IEnumerable<RatingType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public RatingTypeProcess(IBaseDal<RatingType, IDomainList<RatingType, IEnumerable<RatingType>>, int> provider)
            : base(provider)
        {
        }

       
        #endregion

    }
}
