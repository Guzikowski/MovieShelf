using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class BorrowedItemService : BaseEntityService<BorrowedItem, IDomainList<BorrowedItem, IEnumerable<BorrowedItem>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public BorrowedItemService(
            IBaseProcess<BorrowedItem, IDomainList<BorrowedItem, IEnumerable<BorrowedItem>>, int, bool> process)
            : base(process)
        {
        }
      
        #endregion

    }
}
