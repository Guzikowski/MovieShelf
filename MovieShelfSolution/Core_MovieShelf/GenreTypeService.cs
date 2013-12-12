using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class GenreTypeService : BaseLookupService<GenreType, IDomainList<GenreType, IEnumerable<GenreType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members
    
        public GenreTypeService(
            IBaseProcess<GenreType, IDomainList<GenreType, IEnumerable<GenreType>>, int, bool> process)
            : base(process)
        {
        }
        
        #endregion

    }
}
