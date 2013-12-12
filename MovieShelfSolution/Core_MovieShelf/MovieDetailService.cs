using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class MovieDetailService : BaseEntityService<MovieDetail, IDomainList<MovieDetail, IEnumerable<MovieDetail>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieDetailService(
            IBaseProcess<MovieDetail, IDomainList<MovieDetail, IEnumerable<MovieDetail>>, int, bool> process)
            : base(process)
        {
        }
        
        #endregion

    }
}
