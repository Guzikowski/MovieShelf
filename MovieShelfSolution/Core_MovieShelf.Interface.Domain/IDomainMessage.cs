
namespace Core_MovieShelf.Interface.Domain
{
    
    
    public interface IDomainMessage
    {
        EMessageType Type { get; set; }
        EMessageNumber Id { get; set; }
        string Message { get; set; }
    }
}
