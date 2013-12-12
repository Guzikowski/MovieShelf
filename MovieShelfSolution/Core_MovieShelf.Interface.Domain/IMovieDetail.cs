using System;

namespace Core_MovieShelf.Interface.Domain
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IMovie
    /// </summary>
    public interface IMovieDetail : IBaseEntity
    {
        IMovieSeries Series { get; set; }
        IGenreType Genre { get; set; }
        IMovieType Type { get; set; }
        IStatusType Status { get; set; }
        IRatingType Rating { get; set; }
        IViewRatingType ViewRating { get; set; }
        decimal? MonetaryValue { get; set; }
        DateTime? DateCollected { get; set; }
    }
}
