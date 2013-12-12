using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Process;

namespace Core_MovieShelf.Service
{

    public class BorrowerService : BaseEntityService<Borrower, IDomainList<Borrower, IEnumerable<Borrower>>, int, bool>
    {
        #region IProcess<TEntity,TEntityList,TKey> Members

        public BorrowerService(
            IBaseProcess<Borrower, IDomainList<Borrower, IEnumerable<Borrower>>, int, bool> process)
            : base(process)
        {
        }

        
        #endregion

    }
}
