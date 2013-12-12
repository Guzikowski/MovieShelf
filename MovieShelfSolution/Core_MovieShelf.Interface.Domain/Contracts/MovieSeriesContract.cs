using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IMovieSeries
    /// </summary>
    [DataContract]
    public class MovieSeriesContract : BaseEntityContract, IMovieSeriesContract
    {
    }
}
