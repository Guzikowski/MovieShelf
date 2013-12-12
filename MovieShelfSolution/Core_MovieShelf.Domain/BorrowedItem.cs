
using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class BorrowedItem : BaseEntity, IBorrowedItem
    {
        public BorrowedItem() { }
        public BorrowedItem(IBorrowedItem entity) : base(entity)
        {
            _borrowedBy = new Borrower(entity.BorrowedBy);
            _borrowedMovie = new MovieDetail(entity.BorrowedMovie);
            _dateBorrowed = entity.DateBorrowed;
            _dateOverdue = entity.DateOverdue;
            _dateReturned = entity.DateReturned;
        }
        public BorrowedItem(IBorrowedItemContract contract) : base(contract)
        {
            _borrowedBy = new Borrower(contract.BorrowedBy);
            _borrowedMovie = new MovieDetail(contract.BorrowedMovie);
            _dateBorrowed = contract.DateBorrowed;
            _dateOverdue = contract.DateOverdue;
            _dateReturned = contract.DateReturned;
        }

        public IBorrower BorrowedBy
        {
            get { return _borrowedBy; }
            set
            {
                if (_borrowedBy != value)
                {
                    HasChanged = true;
                } 
                _borrowedBy = value;
            }
        }
        private IBorrower _borrowedBy = new Borrower();

        public IMovieDetail BorrowedMovie
        {
            get { return _borrowedMovie; }
            set
            {
                if (_borrowedMovie != value)
                {
                    HasChanged = true;
                } 
                _borrowedMovie = value;
            }
        }
        private IMovieDetail _borrowedMovie = new MovieDetail();

        public DateTime DateBorrowed
        {
            get { return _dateBorrowed; }
            set
            {
                if (_dateBorrowed != value)
                {
                    HasChanged = true;
                }
                _dateBorrowed = value;
            }
        }
        private DateTime _dateBorrowed = DateTime.Now;

        public DateTime DateOverdue
        {
            get { return _dateOverdue; }
            set
            {
                if (_dateOverdue != value)
                {
                    HasChanged = true;
                }
                _dateOverdue = value;
            }
        }
        private DateTime _dateOverdue = DateTime.Now;

        public DateTime? DateReturned
        {
            get { return _dateReturned; }
            set
            {
                if (_dateReturned != value)
                {
                    HasChanged = true;
                } 
                _dateReturned = value;
            }
        }
        private DateTime? _dateReturned = new DateTime?();

        public override bool Validate()
        {
            base.Validate();

            if (!_borrowedBy.Validate())
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidBorrowedBy));
            }
            else if (_borrowedBy.IsNew)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidBorrowedBy));
            }
            if (!_borrowedMovie.Validate())
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidBorrowedMovie));
            }
            else if (_borrowedMovie.IsNew)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidBorrowedBy));
            }
            if (_dateBorrowed == DateTime.MinValue)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorDateBorrowedNotPresent));
            }
            if (_dateBorrowed > DateTime.Now)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrDateBorrowedInFuture));
            }
            if (_dateOverdue < _dateBorrowed)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrDateOverdueMustBeInFuture));
            }
            if (_dateReturned.HasValue)
            {
                if (_dateReturned.Value < _dateBorrowed)
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrDateReturnedMustBeInFuture));
            }
            
            return DomainStatus.GetMessages(EMessageType.Error).Count == 0;

        }
        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseEntity, TEntityContract baseContract)
            where TEntity : BorrowedItem, IBorrowedItem
            where TEntityContract : BorrowedItemContract, new()
        {
            if (baseEntity == null)
            {
                return baseContract;
            }
            baseContract = base.ConvertToContract(baseEntity, baseContract);
            baseContract.DateBorrowed = baseEntity.DateBorrowed;
            baseContract.DateOverdue = baseEntity.DateOverdue;
            baseContract.DateReturned = baseEntity.DateReturned;
            baseContract.BorrowedBy = new Borrower().ConvertToContract((Borrower)baseEntity.BorrowedBy, new BorrowerContract());
            baseContract.BorrowedMovie = new MovieDetail().ConvertToContract((MovieDetail)baseEntity.BorrowedMovie, new MovieDetailContract());
            return baseContract;
        }
        public DomainListContract<TEntityContract> ConvertToContract<TEntity, TEntityList, TEntityContract>(IDomainList<TEntity, TEntityList> domainList)
            where TEntity : BorrowedItem, IBorrowedItem, new()
            where TEntityList : IEnumerable<TEntity>
            where TEntityContract : BorrowedItemContract, new()
        {
            var returnValue = new DomainListContract<TEntityContract>();
            if (domainList == null)
            {
                return returnValue;
            }
            returnValue.DomainStatus = Domain.DomainStatus.ConvertToContract(domainList.DomainStatus);
            returnValue.IsValid = domainList.IsValid;
            returnValue.EntityList = domainList.EntityList.Select(item => new TEntity().ConvertToContract(item, new TEntityContract())).ToList();
            return returnValue;
        }
        public IDomainList<TEntity, TEntityList> ConvertToDomain<TEntity, TEntityList, TEntityContract>(DomainListContract<TEntityContract> contractList)
            where TEntity : BorrowedItem, IBorrowedItem, new()
            where TEntityList : class, IEnumerable<TEntity>
            where TEntityContract : BorrowedItemContract, new()
        {
            var returnValue = new DomainList<TEntity, TEntityList>();
            if (contractList == null)
            {
                return returnValue;
            }
            var itemList = contractList.EntityList.Select(item => new BorrowedItem(item)).Select(item2 => item2 as TEntity).ToList();
            returnValue.EntityList = itemList as TEntityList;
            return returnValue;
        }
    }
}
