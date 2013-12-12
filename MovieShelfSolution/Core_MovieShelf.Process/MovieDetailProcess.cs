using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class MovieDetailProcess : BaseEntityProcess<MovieDetail, IDomainList<MovieDetail, IEnumerable<MovieDetail>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieDetailProcess(IBaseDal<MovieDetail, IDomainList<MovieDetail, IEnumerable<MovieDetail>>, int> provider)
            : base(provider)
        {
        }

        
        #endregion

    }
}
