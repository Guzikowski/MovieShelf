using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IPlatform
    /// </summary>
    [DataContract]
    public class MovieTypeContract : BaseLookupContract, IMovieTypeContract
    {
    }
}
