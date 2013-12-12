using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class MovieSeriesService : BaseEntityService<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieSeriesService(
            IBaseProcess<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int, bool> process)
            : base(process)
        {
        }

       
        #endregion

    }
}
