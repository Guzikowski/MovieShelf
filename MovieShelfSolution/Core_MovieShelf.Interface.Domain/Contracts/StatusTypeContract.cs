using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IStatus
    /// </summary>
    [DataContract]
    public class StatusTypeContract : BaseLookupContract, IStatusTypeContract
    {
    }
}
