using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class GenreTypeProcess : BaseLookupProcess<GenreType, IDomainList<GenreType, IEnumerable<GenreType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public GenreTypeProcess(IBaseDal<GenreType, IDomainList<GenreType, IEnumerable<GenreType>>, int> provider)
            : base(provider)
        {
        }

        
        #endregion

    }
}
