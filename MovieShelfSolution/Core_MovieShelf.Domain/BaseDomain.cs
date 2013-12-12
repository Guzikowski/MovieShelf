
using System;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public abstract class BaseDomain : IBaseDomain
    {
        protected BaseDomain() {}
        protected BaseDomain(IBaseDomain baseDomain)
        {
            _id = baseDomain.Id; 
            _isRemoved = baseDomain.IsRemoved;
            _hasChanged = baseDomain.HasChanged;
            _lastModifiedBy = baseDomain.LastModifiedBy;
            _lastModifiedDate = baseDomain.LastModifiedDate;
            _timestamp = baseDomain.Timestamp;
            //DomainStatus.Messages 
        }
        protected BaseDomain(IBaseDomainContract baseDomain)
        {
            _id = baseDomain.Id;
            _isRemoved = baseDomain.IsRemoved;
            _hasChanged = baseDomain.HasChanged;
            _lastModifiedBy = baseDomain.LastModifiedBy;
            _lastModifiedDate = baseDomain.LastModifiedDate;
            _timestamp = baseDomain.Timestamp;
            //DomainStatus.Messages 
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is new.
        /// </summary>
        /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
        public bool IsNew
        {
            get { return Id <= 0; }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is removed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is removed; otherwise, <c>false</c>.
        /// </value>
        public bool IsRemoved
        {
            get { return _isRemoved && !IsNew; }
            set { _isRemoved = value; }
        }
        private bool _isRemoved;
        /// <summary>
        /// Gets or sets a value indicating whether this instance has changed.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changed; otherwise, <c>false</c>.
        /// </value>
        public bool HasChanged
        {
            get { return _hasChanged && !IsNew; }
            set { _hasChanged = value; }
        }
        private bool _hasChanged;
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id
        {
            get { return _id; }
            set { _id = value > 0 ? value : 0; }
        }
        private int _id;
        /// <summary>
        /// Gets or sets the Last Login that Modified the record.
        /// </summary>
        /// <value>The Last Modified Person.</value>
        public string LastModifiedBy
        {
            get { return _lastModifiedBy; } 
            set { _lastModifiedBy = value ?? string.Empty; }
        }
        private string _lastModifiedBy = string.Empty;
        /// <summary>
        /// Gets or sets the Last date a successful modification occurred.
        /// </summary>
        /// <value>The Last successful modification date.</value>
        public DateTime LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set { _lastModifiedDate = value > DateTime.Now ? DateTime.Now.Date : value; } 
        }
        private DateTime _lastModifiedDate = DateTime.Now.Date;
        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public byte[] Timestamp
        {
            get { return _timestamp; } 
            set { _timestamp = value; }
        }
        private byte[] _timestamp;

        public virtual bool IsValid
        {
            get { return _domainStatus.GetMessages(EMessageType.Error).Count == 0; }
        }
        public virtual bool Validate()
        {
            _domainStatus.ClearMessages(EMessageType.Error);
            if (!IsNew)
            {
                if (string.IsNullOrEmpty(_lastModifiedBy))
                {
                    _domainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorLastModifiedByNotPresent));
                }
                else if (_lastModifiedBy.Length > 100)
                {
                    _domainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong));
                }
                if (_lastModifiedDate == DateTime.MinValue)
                {
                    _domainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorLastModifiedDateNotPresent));
                }
                if (_lastModifiedDate > DateTime.Now)
                {
                    _domainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrLastModifiedDateInFuture));
                }
            }
            return IsValid;
        }
        
        public virtual void Reset()
        {
            HasChanged = false;
            _domainStatus.ClearMessages(EMessageType.All);
        }

        public IDomainStatus DomainStatus
        {
            get { return _domainStatus ?? (_domainStatus = new DomainStatus()); }
        }
        private IDomainStatus _domainStatus = new DomainStatus();


        public BaseDomainContract ConvertToContract(IBaseDomain baseDomain)
        {
            return baseDomain == null
                       ? new BaseDomainContract()
                       : new BaseDomainContract
                             {
                                 IsNew = baseDomain.IsNew,
                                 IsValid = baseDomain.IsValid,
                                 IsRemoved = baseDomain.IsRemoved,
                                 HasChanged = baseDomain.HasChanged,
                                 Id = baseDomain.Id,
                                 LastModifiedBy = baseDomain.LastModifiedBy,
                                 LastModifiedDate = baseDomain.LastModifiedDate,
                                 Timestamp = baseDomain.Timestamp,
                                 DomainStatus = Domain.DomainStatus.ConvertToContract(baseDomain.DomainStatus)
                             };
        }
        public TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseDomain, TEntityContract baseContract)
            where TEntity : BaseDomain
            where TEntityContract : BaseDomainContract, new()
        {
            if (baseDomain == null)
            {
                return baseContract;
            }
            if (baseContract == null)
            {
                return new TEntityContract
                {
                    IsNew = baseDomain.IsNew,
                    IsValid = baseDomain.IsValid,
                    IsRemoved = baseDomain.IsRemoved,
                    HasChanged = baseDomain.HasChanged,
                    Id = baseDomain.Id,
                    LastModifiedBy = baseDomain.LastModifiedBy,
                    LastModifiedDate = baseDomain.LastModifiedDate,
                    Timestamp = baseDomain.Timestamp,
                    DomainStatus = Domain.DomainStatus.ConvertToContract(baseDomain.DomainStatus),
                };
            }
            baseContract.IsNew = baseDomain.IsNew;
            baseContract.IsValid = baseDomain.IsValid;
            baseContract.IsRemoved = baseDomain.IsRemoved;
            baseContract.HasChanged = baseDomain.HasChanged;
            baseContract.Id = baseDomain.Id;
            baseContract.LastModifiedBy = baseDomain.LastModifiedBy;
            baseContract.LastModifiedDate = baseDomain.LastModifiedDate;
            baseContract.Timestamp = baseDomain.Timestamp;
            baseContract.DomainStatus = Domain.DomainStatus.ConvertToContract(baseDomain.DomainStatus);
            return baseContract;
        }
    }
}
