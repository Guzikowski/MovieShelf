using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{

    public class StatusTypeDal : BaseLookupDal<Domain.StatusType, IDomainList<Domain.StatusType, IEnumerable<Domain.StatusType>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public StatusTypeDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.StatusType Read(int key)
        {
            var returnResult = new Domain.StatusType();
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

        public override IDomainList<Domain.StatusType, IEnumerable<Domain.StatusType>> ReadAll()
        {
            var returnResult = new DomainList<Domain.StatusType, IEnumerable<Domain.StatusType>>();
            var result = new List<Domain.StatusType>();
            if (MovieShelfContext.StatusTypes.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.StatusTypes.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.StatusType Add(Domain.StatusType item)
        {
            var returnResult = new Domain.StatusType();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.StatusTypes.AddObject(linqResult);
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
        public override Domain.StatusType Update(Domain.StatusType item)
        {
            var returnResult = new Domain.StatusType();
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
        
        private static Domain.StatusType MapToDomain(StatusType linqResult)
        {
            var result = new Domain.StatusType
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
        private static StatusType MapToDataModel(IStatusType domainEntity)
        {
            var result = new StatusType
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
        private StatusType MergeChange(StatusType changedEntity)
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
        private StatusType FetchEntity(int key)
        {
            var linqResult = new StatusType();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.StatusTypes.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.StatusTypes.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
