using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public abstract class BaseEntity: BaseDomain, IBaseEntity
    {

        protected BaseEntity() { }
        protected BaseEntity(IBaseEntity baseEntity)
            : base(baseEntity)
        {
            _name = baseEntity.Name;
            _displayImage = baseEntity.DisplayImage;
        }
        protected BaseEntity(IBaseEntityContract baseEntity)
            : base(baseEntity)
        {
            _name = baseEntity.Name;
            _displayImage = new DisplayImage(baseEntity.DisplayImage);
        }
        public IDisplayImage DisplayImage
        {
            get { return _displayImage; }
            set
            {
                if (_displayImage != value)
                {
                    HasChanged = true;
                }
                _displayImage = value;
            }
        }
        private IDisplayImage _displayImage = new DisplayImage();

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

        public override bool Validate()
        {
            base.Validate();

            if (!_displayImage.IsNew)
            {
                if (!_displayImage.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidDisplayImage));
                }
            }
            
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
        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseLookup, TEntityContract baseContract)
            where TEntity : BaseDomain, IBaseEntity
            where TEntityContract : BaseEntityContract, new()
        {
            if (baseLookup == null)
            {
                return baseContract;
            }
            baseContract = base.ConvertToContract(baseLookup, baseContract);
            baseContract.Name = baseLookup.Name;
            baseContract.DisplayImage = new DisplayImage().ConvertToContract((DisplayImage)baseLookup.DisplayImage, new DisplayImageContract());
            return baseContract;
        }
    }
}
