using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;

namespace Core_MovieShelf.Data
{
    public class BorrowedItemDal : BaseEntityDal<Domain.BorrowedItem, IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>, int>
    {
        #region IDal<TEntity,TEntityList,TKey> Members

        public BorrowedItemDal(MovieShelfEntities context) : base(context)
        {
        }

        public override Domain.BorrowedItem Read(int key)
        {
            var returnResult = new Domain.BorrowedItem();
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

        public override IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>> ReadAll()
        {
            var returnResult = new DomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>();
            var result = new List<Domain.BorrowedItem>();
            if (MovieShelfContext.BorrowedItems.Count() <= 0)
            {
                returnResult.EntityList = result;
                returnResult.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.NoDataFound));
                return returnResult;
            }
            result.AddRange(MovieShelfContext.BorrowedItems.ToList().Select(MapToDomain));
            returnResult.EntityList = result;
            returnResult.DomainStatus.AddMessage(returnResult.EntityList.Count() > 0
                                                         ? MessageHelper.Get(EMessageNumber.SuccessfulRead)
                                                         : MessageHelper.Get(EMessageNumber.NoDataFound));
            return returnResult;
        }
        public override Domain.BorrowedItem Add(Domain.BorrowedItem item)
        {
            var returnResult = new Domain.BorrowedItem();
            try
            {
                var linqResult = MapToDataModel(item);
                MovieShelfContext.BorrowedItems.AddObject(linqResult);
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
        public override Domain.BorrowedItem Update(Domain.BorrowedItem item)
        {
            var returnResult = new Domain.BorrowedItem();
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

        private static Domain.BorrowedItem MapToDomain(BorrowedItem dataEntity)
        {
            return new Domain.BorrowedItem
            {
                DateBorrowed = dataEntity.DateBorrowed,
                Id = dataEntity.Id,
                LastModifiedBy = dataEntity.ModifiedBy,
                LastModifiedDate = dataEntity.ModifiedDate,
                //Name = dataEntity.Name, 
                DateOverdue = dataEntity.OverdueDate,
                DateReturned = dataEntity.DateReturned,
                Timestamp = dataEntity.TimeStamp,
                BorrowedBy = new Domain.Borrower
                {
                    Id = dataEntity.BorrowerId,
                },
                BorrowedMovie = new Domain.MovieDetail
                {
                    Id = dataEntity.MovieDetailId,
                }
            };
        }
        private static BorrowedItem MapToDataModel(IBorrowedItem domainEntity)
        {
            var result = new BorrowedItem
            {
                DateBorrowed = domainEntity.DateBorrowed,
                Id = domainEntity.Id,
                ModifiedBy = domainEntity.LastModifiedBy,
                ModifiedDate = domainEntity.LastModifiedDate,
                //Name = domainEntity.Name,
                OverdueDate = domainEntity.DateOverdue,
                DateReturned = domainEntity.DateReturned,
                TimeStamp = domainEntity.Timestamp,
                BorrowerId = domainEntity.BorrowedBy.Id,
                MovieDetailId = domainEntity.BorrowedMovie.Id,
            };
            
            return result;
        }
        private BorrowedItem MergeChange(BorrowedItem changedEntity)
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
            originalEntity.DateBorrowed = changedEntity.DateBorrowed;
            originalEntity.ModifiedBy = changedEntity.ModifiedBy;
            originalEntity.ModifiedDate = changedEntity.ModifiedDate;
            //originalEntity.Name = changedEntity.Name;
            originalEntity.OverdueDate = changedEntity.OverdueDate;
            originalEntity.DateReturned = changedEntity.DateReturned;
            originalEntity.BorrowerId = changedEntity.BorrowerId;
            originalEntity.MovieDetailId = changedEntity.MovieDetailId;
            return originalEntity;
        }
        private BorrowedItem FetchEntity(int key)
        {
            var linqResult = new BorrowedItem();
            // Get the first LINQ to SQL customer entity
            // instance with the provided key
            if (MovieShelfContext.BorrowedItems.Where(b => b.Id == key).Count() > 0)
            {
                linqResult = MovieShelfContext.BorrowedItems.First(b => b.Id == key);
            }
            return linqResult;
        }
    }
   
}
