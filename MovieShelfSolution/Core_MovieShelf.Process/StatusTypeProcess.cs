using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class StatusTypeProcess : BaseLookupProcess<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public StatusTypeProcess(IBaseDal<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int> provider)
            : base(provider)
        {
        }
        
        #endregion

    }
}
