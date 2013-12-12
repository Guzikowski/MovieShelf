using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class MovieTypeDal : BaseLookupDal<Domain.MovieType, IDomainList<Domain.MovieType, IEnumerable<Domain.MovieType>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public MovieTypeDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.MovieType Read(int key)
        {
            var returnResult = new Domain.MovieType();
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
        public override IDomainList<Domain.MovieType, IEnumerable<Domain.MovieType>> ReadAll()
        {
            var returnResult = new DomainList<Domain.MovieType, IEnumerable<Domain.MovieType>>();
            var result = new List<Domain.MovieType>();
            if (MovieShelfContext.MovieTypes.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.MovieTypes.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.MovieType Add(Domain.MovieType item)
        {
            var returnResult = new Domain.MovieType();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.MovieTypes.AddObject(linqResult);
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
        public override Domain.MovieType Update(Domain.MovieType item)
        {
            var returnResult = new Domain.MovieType();
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
        private static Domain.MovieType MapToDomain(MovieType linqResult)
        {
            var result = new Domain.MovieType
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
        private static MovieType MapToDataModel(IMovieType domainEntity)
        {
            var result = new MovieType
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
        private MovieType MergeChange(MovieType changedEntity)
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
        private MovieType FetchEntity(int key)
        {
            var linqResult = new MovieType();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.MovieTypes.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.MovieTypes.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
