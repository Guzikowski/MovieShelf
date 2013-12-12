using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class MovieTypeService : BaseLookupService<MovieType, IDomainList<MovieType, IEnumerable<MovieType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieTypeService(
            IBaseProcess<MovieType, IDomainList<MovieType, IEnumerable<MovieType>>, int, bool> process)
            : base(process)
        {
        }
       
        #endregion

    }
}
