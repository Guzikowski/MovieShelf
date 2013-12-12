using System;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IMovie
    /// </summary>
    public interface IMovieDetailContract : IBaseEntityContract
    {
        MovieSeriesContract Series { get; set; }
        GenreTypeContract Genre { get; set; }
        MovieTypeContract Type { get; set; }
        StatusTypeContract Status { get; set; }
        RatingTypeContract Rating { get; set; }
        ViewRatingTypeContract ViewRating { get; set; }
        decimal? MonetaryValue { get; set; }
        DateTime? DateCollected { get; set; }
    }
}
