using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{
    public class GenreTypeDal : BaseLookupDal<Domain.GenreType, IDomainList<Domain.GenreType, IEnumerable<Domain.GenreType>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public GenreTypeDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.GenreType Read(int key)
        {
            var returnResult = new Domain.GenreType();
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
        public override IDomainList<Domain.GenreType, IEnumerable<Domain.GenreType>> ReadAll()
        {
            var returnResult = new DomainList<Domain.GenreType, IEnumerable<Domain.GenreType>>();
            var result = new List<Domain.GenreType>();
            if (MovieShelfContext.GenreTypes.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.GenreTypes.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.GenreType Add(Domain.GenreType item)
        {
            var returnResult = new Domain.GenreType();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.GenreTypes.AddObject(linqResult);
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
        public override Domain.GenreType Update(Domain.GenreType item)
        {
            var returnResult = new Domain.GenreType();
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
            IDomainStatus returnResult = new DomainStatus();
            try
            {
                var itemFound = MovieShelfContext.GenreTypes.FirstOrDefault(i => i.Id == key);
                if (itemFound.Id != key)
                {
                    returnResult.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                    return returnResult;
                }
                if (!itemFound.IsDeleted)
                {
                    returnResult.AddMessage(MessageHelper.Get(EMessageNumber.DeletionErrorStillActive));
                    return returnResult;
                }
                returnResult = InUse(itemFound.Id);
                if (!returnResult.IsValid)
                {
                    return returnResult;
                }
                MovieShelfContext.GenreTypes.DeleteObject(itemFound);
                MovieShelfContext.SaveChanges();
                returnResult.AddMessage(MessageHelper.Get(EMessageNumber.SuccessfulDelete));
            }
            catch (Exception exception)
            {
                returnResult.AddExceptionMessage(exception);
            }
            return returnResult;
        }
        public override IDomainStatus InUse(int key)
        {
            //TODO: Code this
            IDomainStatus returnResult = new DomainStatus();
            returnResult.AddMessage(MessageHelper.Get(EMessageNumber.SuccessfulOperationCheck));
            returnResult.AddMessage(MessageHelper.Get(EMessageNumber.DeletionErrorStillInUse));
            return returnResult;
        }

        #endregion
        private static Domain.GenreType MapToDomain(GenreType dataEntity)
        {
            var result = new Domain.GenreType
            {
                Id = dataEntity.Id,
                IsRemoved = dataEntity.IsDeleted,
                LastModifiedBy = dataEntity.ModifiedBy,
                LastModifiedDate = dataEntity.ModifiedDate,
                Name = dataEntity.Name,
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
        private static GenreType MapToDataModel(IGenreType domainEntity)
        {
            var result = new GenreType
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
        private GenreType MergeChange(GenreType changedEntity)
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
        private GenreType FetchEntity(int key)
        {
            var linqResult = new GenreType();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.GenreTypes.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.GenreTypes.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
}
