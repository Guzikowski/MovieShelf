using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Process
{

    public class BorrowerProcess : BaseEntityProcess<Borrower, IDomainList<Borrower, IEnumerable<Borrower>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public BorrowerProcess(IBaseDal<Borrower, IDomainList<Borrower, IEnumerable<Borrower>>, int> provider)
            : base(provider)
        {
        }

        
        #endregion

    }
}
