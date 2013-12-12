using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class StatusTypeService : BaseLookupService<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public StatusTypeService(
            IBaseProcess<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int, bool> process)
            : base(process)
        {
        }
        
        #endregion

    }
}
