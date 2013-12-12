using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;


namespace Core_MovieShelf.Data
{

    public class MovieSeriesDal : BaseEntityDal<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public MovieSeriesDal(MovieShelfEntities context) : base(context)
        {
        }

        public override MovieSeries Read(int key)
        {
            var returnResult = new MovieSeries();
            try
            {
                returnResult = MapToDomain(FetchEntity(key));
                returnResult.DomainStatus.AddMessage(returnResult.Id == key
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            }
            catch (Exception exception)
            {
                returnResult.DomainStatus.AddExceptionMessage(exception);
            }
            return returnResult;
        }
        public override IDomainList<MovieSeries, IEnumerable<MovieSeries>> ReadAll()
        {
            var returnResult = new DomainList<MovieSeries, IEnumerable<MovieSeries>>();
            var result = new List<MovieSeries>();
            if (MovieShelfContext.MovieSeries.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.MovieSeries.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override MovieSeries Add(MovieSeries item)
        {
            var returnResult = new MovieSeries();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.MovieSeries.AddObject(linqResult);
                MovieShelfContext.SaveChanges();
                returnResult = MapToDomain(linqResult);
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.SuccessfulAdd));
            }
            catch (Exception exception)
            {
                returnResult.DomainStatus.AddExceptionMessage(exception);
            }
            return returnResult;
        }
        public override MovieSeries Update(MovieSeries item)
        {
            var returnResult = new MovieSeries();
            try
            {
                var linqResult = MapToDataModel(item);
                var mergedEntity = MergeChange(linqResult);
                MovieShelfContext.SaveChanges();
                returnResult = MapToDomain(mergedEntity);
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.SuccessfulUpdate));
            }
            catch (Exception exception)
            {
                returnResult.DomainStatus.AddExceptionMessage(exception);
            }
            return returnResult;
        }
        public override IDomainStatus Delete(int key)
        {
            throw new NotImplementedException();
        }
        public override IDomainStatus InUse(int key)
        {
            throw new NotImplementedException();
        }
        #endregion
        private static MovieSeries MapToDomain(MovieSery linqResult)
        {
            var result = new MovieSeries
            {
                Id = linqResult.Id,
                IsRemoved = linqResult.IsDeleted,
                LastModifiedBy = linqResult.ModifiedBy,
                LastModifiedDate = linqResult.ModifiedDate,
                Name = linqResult.Name,
                Timestamp = linqResult.TimeStamp
            };
            if (linqResult.DisplayImageId.HasValue)
            {
                result.DisplayImage = new Domain.DisplayImage
                {
                    Id = linqResult.DisplayImageId.Value,

                };
            }
            return result;
        }
        private static MovieSery MapToDataModel(IMovieSeries domainEntity)
        {
            var result = new MovieSery
            {
                Id = domainEntity.Id,
                ModifiedBy = domainEntity.LastModifiedBy,
                ModifiedDate = domainEntity.LastModifiedDate,
                Name = domainEntity.Name,
                TimeStamp = domainEntity.Timestamp
            };
            if (domainEntity.DisplayImage != null)
            {
                if (domainEntity.DisplayImage.Id > 0)
                {
                    result.DisplayImageId = domainEntity.DisplayImage.Id;
                }
            }
            return result;
        }
        private MovieSery MergeChange(MovieSery changedEntity)
        {
            var originalEntity = FetchEntity(changedEntity.Id);
            if (originalEntity.Id != changedEntity.Id)
            {
                return originalEntity;
            }
            if (originalEntity.TimeStamp == changedEntity.TimeStamp)
            {
                return originalEntity;
            }
            originalEntity.DisplayImageId = changedEntity.DisplayImageId;
            originalEntity.ModifiedBy = changedEntity.ModifiedBy;
            originalEntity.ModifiedDate = changedEntity.ModifiedDate;
            originalEntity.Name = changedEntity.Name;
            return originalEntity;
        }
        private MovieSery FetchEntity(int key)
        {
            var linqResult = new MovieSery();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.MovieSeries.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.MovieSeries.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
