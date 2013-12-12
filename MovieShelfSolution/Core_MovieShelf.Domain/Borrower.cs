using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class Borrower : BaseEntity, IBorrower
    {
        public Borrower() { }
        public Borrower(IBorrower entity) : base(entity)
        {
            _email = entity.Email;
            _phone = entity.Phone;
        }
        public Borrower(IBorrowerContract contract) : base(contract)
        {
            _email = contract.Email;
            _phone = contract.Phone;
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    HasChanged = true;
                } 
                _email = value;
            }
        }
        private string _email = string.Empty;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    HasChanged = true;
                } 
                _phone = value;
            }
        }
        private string _phone = string.Empty;

        public override bool Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(_email) && string.IsNullOrEmpty(_phone))
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorContactDetailsNotPresent));
            }
            else
            {
                if (!string.IsNullOrEmpty(_email))
                {
                    if (_email.Length > 25)
                    {
                        DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorEmailToLong));
                    }
                }
                if (!string.IsNullOrEmpty(_phone))
                {
                    if (_phone.Length > 15)
                    {
                        DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorPhoneToLong));
                    }
                }
            }
            return DomainStatus.GetMessages(EMessageType.Error).Count == 0;

        }
        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseEntity, TEntityContract baseContract)
            where TEntity : Borrower, IBorrower
            where TEntityContract : BorrowerContract, new()
        {
            if (baseEntity == null)
            {
                return baseContract;
            }
            baseContract = base.ConvertToContract(baseEntity, baseContract);
            baseContract.Email = baseEntity.Email;
            baseContract.Phone = baseEntity.Phone;
            return baseContract;
        }
        public DomainListContract<TEntityContract> ConvertToContract<TEntity, TEntityList, TEntityContract>(IDomainList<TEntity, TEntityList> domainList)
            where TEntity : Borrower, IBorrower, new()
            where TEntityList : IEnumerable<TEntity>
            where TEntityContract : BorrowerContract, new()
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
            where TEntity : Borrower, IBorrower, new()
            where TEntityList : class, IEnumerable<TEntity>
            where TEntityContract : BorrowerContract, new()
        {
            var returnValue = new DomainList<TEntity, TEntityList>();
            if (contractList == null)
            {
                return returnValue;
            }
            var itemList = contractList.EntityList.Select(item => new Borrower(item)).Select(item2 => item2 as TEntity).ToList();
            returnValue.EntityList = itemList as TEntityList;
            return returnValue;
        }
    }
}
