using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{

    public class DomainList<TEntity, TEntityList> : IDomainList<TEntity, TEntityList>
        where TEntity : BaseDomain, new() 
        where TEntityList : IEnumerable<TEntity>
    {
        public virtual bool IsValid
        {
            get { return _domainStatus.GetMessages(EMessageType.Error).Count == 0; }
        }
        public virtual bool Validate()
        {
            _domainStatus.ClearMessages(EMessageType.Error);

            if (EntityList.Any(item => !item.IsValid))
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.EntityListContainsErrors));
            }

            return IsValid;
        }
        public virtual void Reset()
        {
            _domainStatus.ClearMessages(EMessageType.All);
        }

        public TEntityList EntityList { get; set; }

        public IDomainStatus DomainStatus
        {
            get { return _domainStatus ?? (_domainStatus = new DomainStatus()); }
        }
        private IDomainStatus _domainStatus = new DomainStatus();

        public DomainList()
        {
            EntityList = default(TEntityList);
        }
    }
}
