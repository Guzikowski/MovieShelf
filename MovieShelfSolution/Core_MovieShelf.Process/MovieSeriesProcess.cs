using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class MovieSeriesProcess : BaseEntityProcess<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieSeriesProcess(IBaseDal<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int> provider)
            : base(provider)
        {
        }

       
        #endregion

    }
}
