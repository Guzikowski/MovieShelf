using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class MovieDetailDal : BaseEntityDal<Domain.MovieDetail, IDomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public MovieDetailDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.MovieDetail Read(int key)
        {
            var returnResult = new Domain.MovieDetail();
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
        public override IDomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>> ReadAll()
        {
   
            var returnResult = new DomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>>();
            var result = new List<Domain.MovieDetail>();
            if (MovieShelfContext.MovieDetails.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.MovieDetails.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.MovieDetail Add(Domain.MovieDetail item)
        {
            var returnResult = new Domain.MovieDetail();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.MovieDetails.AddObject(linqResult);
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
        public override Domain.MovieDetail Update(Domain.MovieDetail item)
        {
            var returnResult = new Domain.MovieDetail();
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
        private static Domain.MovieDetail MapToDomain(MovieDetail dataEntity)
        {
            var result = new Domain.MovieDetail
            {
                Id = dataEntity.Id,
                LastModifiedBy = dataEntity.ModifiedBy,
                LastModifiedDate = dataEntity.ModifiedDate,
                Name = dataEntity.Title,
                Timestamp = dataEntity.TimeStamp
            };
            if (dataEntity.DisplayImageId.HasValue)
            {
                result.DisplayImage = new Domain.DisplayImage
                {
                    Id = dataEntity.DisplayImageId.Value,

                };
            }
            return result;
        }
        private static MovieDetail MapToDataModel(Domain.MovieDetail domainEntity)
        {
            var result = new MovieDetail
            {
                Id = domainEntity.Id,
                ModifiedBy = domainEntity.LastModifiedBy,
                ModifiedDate = domainEntity.LastModifiedDate,
                Title = domainEntity.Name,
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
        private MovieDetail MergeChange(MovieDetail changedEntity)
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
            originalEntity.Title = changedEntity.Title;
            return originalEntity;
        }
        private MovieDetail FetchEntity(int key)
        {
            var linqResult = new MovieDetail();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.MovieDetails.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.MovieDetails.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
