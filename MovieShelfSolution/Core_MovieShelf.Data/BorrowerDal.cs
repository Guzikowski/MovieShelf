using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{
    public class BorrowerDal : BaseEntityDal<Domain.Borrower, IDomainList<Domain.Borrower, IEnumerable<Domain.Borrower>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public BorrowerDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.Borrower Read(int key)
        {
            var returnResult = new Domain.Borrower();
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
        public override IDomainList<Domain.Borrower, IEnumerable<Domain.Borrower>> ReadAll()
        {
            var returnResult = new DomainList<Domain.Borrower, IEnumerable<Domain.Borrower>>();
            var result = new List<Domain.Borrower>();
            if (MovieShelfContext.Borrowers.Count() < 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.Borrowers.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.Borrower Add(Domain.Borrower item)
        {
            var returnResult = new Domain.Borrower();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.Borrowers.AddObject(linqResult);
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
        public override Domain.Borrower Update(Domain.Borrower item)
        {
            var returnResult = new Domain.Borrower();
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
        private static Domain.Borrower MapToDomain(Borrower dataEntity)
        {
            var result = new Domain.Borrower
            {
                Email = dataEntity.Email,
                Id = dataEntity.Id,
                IsRemoved = dataEntity.IsDeleted.HasValue ? dataEntity.IsDeleted.Value : false,
                LastModifiedBy = dataEntity.ModifiedBy,
                LastModifiedDate = dataEntity.ModifiedDate,
                Name = dataEntity.Name,
                Phone = dataEntity.Phone,
                Timestamp = dataEntity.TimeStamp
            };
            if (dataEntity.DisplayImageId.HasValue)
            {
                result.DisplayImage = new Domain.DisplayImage
                {
                    Id = dataEntity.DisplayImageId.Value,
                    LastModifiedBy = dataEntity.ModifiedBy,
                    LastModifiedDate = dataEntity.ModifiedDate,

                };
            }
            return result;
        }
        private static Borrower MapToDataModel(IBorrower domainEntity)
        {
            var result = new Borrower
            {
                Email = domainEntity.Email,
                Id = domainEntity.Id,
                ModifiedBy = domainEntity.LastModifiedBy,
                ModifiedDate = domainEntity.LastModifiedDate,
                Name = domainEntity.Name,
                Phone = domainEntity.Phone,
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
        private Borrower MergeChange(Borrower changedEntity)
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
        private Borrower FetchEntity(int key)
        {
            var linqResult = new Borrower();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.Borrowers.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.Borrowers.First(b => b.Id == key);
            }
            return linqResult;
        }
    }

}
