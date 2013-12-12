using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IGenre
    /// </summary>
    [DataContract]
    public class GenreTypeContract : BaseLookupContract, IGenreTypeContract
    {
    }
}
