
using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class MovieDetail : BaseEntity, IMovieDetail
    {
        public MovieDetail() { }
        public MovieDetail(IMovieDetail entity) : base(entity)
        {
            _dateCollected = entity.DateCollected;
            _genre = new GenreType(entity.Genre);
            _monetaryValue = entity.MonetaryValue;
            _rating = new RatingType(entity.Rating);
            _series = new MovieSeries(entity.Series);
            _status = new StatusType(entity.Status);
            _type = new MovieType(entity.Type);
            _viewRating = new ViewRatingType(entity.ViewRating);
        }
        public MovieDetail(IMovieDetailContract contract) : base(contract)
        {
            _dateCollected = contract.DateCollected;
            _genre = new GenreType(contract.Genre);
            _monetaryValue = contract.MonetaryValue;
            _rating = new RatingType(contract.Rating);
            _series = new MovieSeries(contract.Series);
            _status = new StatusType(contract.Status);
            _type = new MovieType(contract.Type);
            _viewRating = new ViewRatingType(contract.ViewRating);
        }

        public IMovieSeries Series
        {
            get { return _series; }
            set { _series = value; }
        }
        private IMovieSeries _series = new MovieSeries();

        public IGenreType Genre
        {
            get { return _genre; }
            set { _genre = value; }
        }
        private IGenreType _genre = new GenreType();

        public IMovieType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private IMovieType _type = new MovieType();

        public IStatusType Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private IStatusType _status = new StatusType();

        public IRatingType Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        private IRatingType _rating = new RatingType();

        public IViewRatingType ViewRating
        {
            get { return _viewRating; }
            set { _viewRating = value; }
        }
        private IViewRatingType _viewRating = new ViewRatingType();

        public decimal? MonetaryValue
        {
            get { return _monetaryValue; }
            set { _monetaryValue = value; }
        }
        private decimal? _monetaryValue = new decimal?();

        public DateTime? DateCollected
        {
            get { return _dateCollected; }
            set { _dateCollected = value; }
        }
        private DateTime? _dateCollected = new DateTime?();

        public override bool Validate()
        {
            base.Validate();


            if (!_series.IsNew)
            {
                if (!_series.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidSeries));
                }
            }
            if (!_genre.IsNew)
            {
                if (!_genre.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidGenre));
                }
            }
            if (!_type.IsNew)
            {
                if (!_type.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidType));
                }
            }
            if (!_status.IsNew)
            {
                if (!_status.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidStatus));
                }
            }
            if (!_rating.IsNew)
            {
                if (!_rating.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidRating));
                }
            }
            if (!_viewRating.IsNew)
            {
                if (!_viewRating.Validate())
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidViewRating));
                }
            }
            if (_monetaryValue.HasValue)
            {
                if (_monetaryValue.Value < 0 || _monetaryValue > 200)
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrInvalidMonetaryValue));
                }
            }
            if (_dateCollected.HasValue)
            {
                if (_dateCollected.Value > DateTime.Now)
                {
                    DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErorrCollectedDateInFuture));
                }
            }
            return DomainStatus.GetMessages(EMessageType.Error).Count == 0;
        }

        public new TEntityContract ConvertToContract<TEntity, TEntityContract>(TEntity baseEntity, TEntityContract baseContract)
            where TEntity : MovieDetail, IMovieDetail
            where TEntityContract : MovieDetailContract, new()
        {
            if (baseEntity == null)
            {
                return baseContract;
            }
            baseContract = base.ConvertToContract(baseEntity, baseContract);

            baseContract.Series = new MovieSeries().ConvertToContract((MovieSeries)baseEntity.Series, new MovieSeriesContract());
            baseContract.Genre = new GenreType().ConvertToContract((GenreType)baseEntity.Genre, new GenreTypeContract());
            baseContract.Type = new MovieType().ConvertToContract((MovieType)baseEntity.Type, new MovieTypeContract());
            baseContract.Status = new StatusType().ConvertToContract((StatusType)baseEntity.Status, new StatusTypeContract());
            baseContract.Rating = new RatingType().ConvertToContract((RatingType)baseEntity.Rating, new RatingTypeContract());
            baseContract.ViewRating = new ViewRatingType().ConvertToContract((ViewRatingType)baseEntity.ViewRating, new ViewRatingTypeContract());
            baseContract.MonetaryValue = baseEntity.MonetaryValue;
            baseContract.DateCollected = baseEntity.DateCollected;
            return baseContract;
        }
        public DomainListContract<TEntityContract> ConvertToContract<TEntity, TEntityList, TEntityContract>(IDomainList<TEntity, TEntityList> domainList)
            where TEntity : MovieDetail, IMovieDetail, new()
            where TEntityList : IEnumerable<TEntity>
            where TEntityContract : MovieDetailContract, new()
        {
            var returnValue = new DomainListContract<TEntityContract>();
            if (domainList == null)
            {
                return returnValue;
            }
            returnValue.DomainStatus = Domain.DomainStatus.ConvertToContract(domainList.DomainStatus);
            returnValue.IsValid = domainList.IsValid;
            returnValue.EntityList = domainList.EntityList.Select(item => new TEntity().ConvertToContract(item, new TEntityContract())).ToList();
            return returnValue;
        }
        public IDomainList<TEntity, TEntityList> ConvertToDomain<TEntity, TEntityList, TEntityContract>(DomainListContract<TEntityContract> contractList)
            where TEntity : MovieDetail, IMovieDetail, new()
            where TEntityList : class, IEnumerable<TEntity>
            where TEntityContract : MovieDetailContract, new()
        {
            var returnValue = new DomainList<TEntity, TEntityList>();
            if (contractList == null)
            {
                return returnValue;
            }
            var itemList = contractList.EntityList.Select(item => new MovieDetail(item)).Select(item2 => item2 as TEntity).ToList();
            returnValue.EntityList = itemList as TEntityList;
            return returnValue;
        }
    }
}
