
namespace Core_MovieShelf.Interface.Domain.Contracts
{
    
    
    public interface IDomainMessageContract
    {
        EMessageType Type { get; set; }
        EMessageNumber Id { get; set; }
        string Message { get; set; }
    }
}
