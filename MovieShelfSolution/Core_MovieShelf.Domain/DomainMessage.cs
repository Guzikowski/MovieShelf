
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class DomainMessage : IDomainMessage
    {
        public EMessageType Type { get; set; }
        public EMessageNumber Id { get; set; }
        public string Message { get; set; }

        public static DomainMessageContract ConvertToContract(IDomainMessage domainMessage)
        {
            if (domainMessage == null)
            {
                return new DomainMessageContract();
            }

            return new DomainMessageContract
            {
                Type = domainMessage.Type,
                Id = domainMessage.Id,
                Message = domainMessage.Message
            };
        }
    }
}
