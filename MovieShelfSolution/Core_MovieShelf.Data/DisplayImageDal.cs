using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{
    public class DisplayImageDal : BaseDal<Domain.DisplayImage, IDomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public DisplayImageDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.DisplayImage Read(int key)
        {
            var returnResult = new Domain.DisplayImage();
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
        public override IDomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>> ReadAll()
        {
            var returnResult = new DomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>>();
            var result = new List<Domain.DisplayImage>();
            if (MovieShelfContext.DisplayImages.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.DisplayImages.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.DisplayImage Add(Domain.DisplayImage item)
        {
            var returnResult = new Domain.DisplayImage();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.DisplayImages.AddObject(linqResult);
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
        public override Domain.DisplayImage Update(Domain.DisplayImage item)
        {
            var returnResult = new Domain.DisplayImage();
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
        private static Domain.DisplayImage MapToDomain(DisplayImage dataEntity)
        {
            return new Domain.DisplayImage
            {
                Id = dataEntity.Id,
                IsRemoved = dataEntity.IsDeleted.HasValue ? dataEntity.IsDeleted.Value : false,
                LastModifiedBy = dataEntity.ModifiedBy,
                LastModifiedDate = dataEntity.ModifiedDate,
                Name = dataEntity.Name,
                Path = dataEntity.Location,
                Timestamp = dataEntity.TimeStamp
            };
        }
        private static DisplayImage MapToDataModel(IDisplayImage domainEntity)
        {
            var result = new DisplayImage
            {
                Id = domainEntity.Id,
                ModifiedBy = domainEntity.LastModifiedBy,
                ModifiedDate = domainEntity.LastModifiedDate,
                Name = domainEntity.Name,
                Location = domainEntity.Path,
                TimeStamp = domainEntity.Timestamp
            };
           
            return result;
        }
        private DisplayImage MergeChange(DisplayImage changedEntity)
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
            originalEntity.ModifiedBy = changedEntity.ModifiedBy;
            originalEntity.ModifiedDate = changedEntity.ModifiedDate;
            originalEntity.Name = changedEntity.Name;
            return originalEntity;
        }
        private DisplayImage FetchEntity(int key)
        {
            var linqResult = new DisplayImage();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.DisplayImages.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.DisplayImages.First(b => b.Id == key);
            }
            return linqResult;
        }
    }


   
}
