
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class DisplayImage : BaseDomain, IDisplayImage
    {
        public DisplayImage() { }
        public DisplayImage(IDisplayImage baseLookup)
            : base(baseLookup)
        {
            _name = baseLookup.Name;
            _path = baseLookup.Path;
        }
        public DisplayImage(IDisplayImageContract baseLookup)
            : base(baseLookup)
        {
            _name = baseLookup.Name;
            _path = baseLookup.Path;
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    HasChanged = true;
                }
                _name = value;
            }
        }
        private string _name = string.Empty;
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    HasChanged = true;
                }
                _path = value;
            }
        }
        private string _path = string.Empty;

        public override bool Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(_name))
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorNameNotPresent));
            }
            else if (_name.Length > 100)
            {
                DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorNameToLong));
            }
            return DomainStatus.GetMessages(EMessageType.Error).Count == 0;
        }
        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseEntity, TEntityContract baseContract)
            where TEntity : DisplayImage, IDisplayImage
            where TEntityContract : DisplayImageContract, new()
        {
            if (baseEntity == null)
            {
                return baseContract;
            }
            baseContract = base.ConvertToContract(baseEntity, baseContract);
            baseContract.Name = baseEntity.Name;
            return baseContract;
        }
        public DomainListContract<TEntityContract> ConvertToContract<TEntity, TEntityList, TEntityContract>(IDomainList<TEntity, TEntityList> domainList)
            where TEntity : DisplayImage, IDisplayImage, new()
            where TEntityList : IEnumerable<TEntity>
            where TEntityContract : DisplayImageContract, new()
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
            where TEntity : DisplayImage, IDisplayImage, new()
            where TEntityList : class, IEnumerable<TEntity>
            where TEntityContract : DisplayImageContract, new()
        {
            var returnValue = new DomainList<TEntity, TEntityList>();
            if (contractList == null)
            {
                return returnValue;
            }
            var itemList = contractList.EntityList.Select(item => new DisplayImage(item)).Select(item2 => item2 as TEntity).ToList();
            returnValue.EntityList = itemList as TEntityList;
            return returnValue;
        }
    }
}
