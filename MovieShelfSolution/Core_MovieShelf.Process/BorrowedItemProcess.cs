using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class BorrowedItemProcess : BaseEntityProcess<BorrowedItem, IDomainList<BorrowedItem, IEnumerable<BorrowedItem>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public BorrowedItemProcess(IBaseDal<BorrowedItem, IDomainList<BorrowedItem, IEnumerable<BorrowedItem>>, int> provider)
            : base(provider)
        {
        }

       
        #endregion

    }
}
