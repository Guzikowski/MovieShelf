using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class ViewRatingTypeDal : BaseLookupDal<Domain.ViewRatingType, IDomainList<Domain.ViewRatingType, IEnumerable<Domain.ViewRatingType>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public ViewRatingTypeDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.ViewRatingType Read(int key)
        {
            var returnResult = new Domain.ViewRatingType();
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
        public override IDomainList<Domain.ViewRatingType, IEnumerable<Domain.ViewRatingType>> ReadAll()
        {
            var returnResult = new DomainList<Domain.ViewRatingType, IEnumerable<Domain.ViewRatingType>>();
            var result = new List<Domain.ViewRatingType>();
            if (MovieShelfContext.ViewRatingTypes.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.ViewRatingTypes.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.ViewRatingType Add(Domain.ViewRatingType item)
        {
            var returnResult = new Domain.ViewRatingType();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.ViewRatingTypes.AddObject(linqResult);
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
        public override Domain.ViewRatingType Update(Domain.ViewRatingType item)
        {
            var returnResult = new Domain.ViewRatingType();
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
        private static Domain.ViewRatingType MapToDomain(ViewRatingType linqResult)
        {
            var result = new Domain.ViewRatingType
            {
                Id = linqResult.Id,
                IsRemoved = linqResult.IsDeleted.HasValue,
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
        private static ViewRatingType MapToDataModel(IViewRatingType domainEntity)
        {
            var result = new ViewRatingType
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
        private ViewRatingType MergeChange(ViewRatingType changedEntity)
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
        private ViewRatingType FetchEntity(int key)
        {
            var linqResult = new ViewRatingType();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.ViewRatingTypes.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.ViewRatingTypes.First(b => b.Id == key);   
            }
            return linqResult;
        }
    }
}
