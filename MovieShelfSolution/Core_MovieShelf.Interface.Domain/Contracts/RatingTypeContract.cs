using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IRating
    /// </summary>
    [DataContract]
    public class RatingTypeContract : BaseLookupContract, IRatingTypeContract
    {
    }
}
