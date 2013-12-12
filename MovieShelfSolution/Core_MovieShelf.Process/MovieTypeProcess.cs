using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class MovieTypeProcess : BaseLookupProcess<MovieType, IDomainList<MovieType, IEnumerable<MovieType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public MovieTypeProcess(IBaseDal<MovieType, IDomainList<MovieType, IEnumerable<MovieType>>, int> provider)
            : base(provider)
        {
        }

       
        #endregion

    }
}
