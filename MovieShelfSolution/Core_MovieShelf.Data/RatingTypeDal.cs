using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class RatingTypeDal : BaseLookupDal<Domain.RatingType, IDomainList<Domain.RatingType, IEnumerable<Domain.RatingType>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public RatingTypeDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.RatingType Read(int key)
        {
            var returnResult = new Domain.RatingType();
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
        public override IDomainList<Domain.RatingType, IEnumerable<Domain.RatingType>> ReadAll()
        {
            var returnResult = new DomainList<Domain.RatingType, IEnumerable<Domain.RatingType>>();
            var result = new List<Domain.RatingType>();
            if (MovieShelfContext.RatingTypes.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.RatingTypes.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.RatingType Add(Domain.RatingType item)
        {
            var returnResult = new Domain.RatingType();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.RatingTypes.AddObject(linqResult);
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
        public override Domain.RatingType Update(Domain.RatingType item)
        {
            var returnResult = new Domain.RatingType();
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
        private static Domain.RatingType MapToDomain(RatingType linqResult)
        {
            var result = new Domain.RatingType
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
        private static RatingType MapToDataModel(IRatingType domainEntity)
        {
            var result = new RatingType
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
        private RatingType MergeChange(RatingType changedEntity)
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
        private RatingType FetchEntity(int key)
        {
            var linqResult = new RatingType();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.RatingTypes.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.RatingTypes.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
