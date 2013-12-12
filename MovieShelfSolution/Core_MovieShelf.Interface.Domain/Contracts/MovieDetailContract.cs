using System;
using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IMovie
    /// </summary>
    [DataContract]
    public class MovieDetailContract : BaseEntityContract, IMovieDetailContract
    {
        [DataMember]
        public MovieSeriesContract Series { get; set; }
        [DataMember]
        public GenreTypeContract Genre { get; set; }
        [DataMember]
        public MovieTypeContract Type { get; set; }
        [DataMember]
        public StatusTypeContract Status { get; set; }
        [DataMember]
        public RatingTypeContract Rating { get; set; }
        [DataMember]
        public ViewRatingTypeContract ViewRating { get; set; }
        [DataMember]
        public decimal? MonetaryValue { get; set; }
        [DataMember]
        public DateTime? DateCollected { get; set; }
    }
}
