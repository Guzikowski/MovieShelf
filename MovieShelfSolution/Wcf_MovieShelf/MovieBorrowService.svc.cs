using System;
using System.Collections.Generic;
using System.Configuration;
using Core_MovieShelf.Data;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using Core_MovieShelf.Process;
using Core_MovieShelf.Service;
using BorrowedItem = Core_MovieShelf.Domain.BorrowedItem;
using Borrower = Core_MovieShelf.Domain.Borrower;


namespace Wcf_MovieShelf
{
    public class MovieBorrowService : BaseService, IMovieBorrowService
    {
        public string HelloService(string greeting)
        {
            return string.Format("The MovieBorrowerService says HI!, and thanks for the following: {0}", greeting);
        }

        public BorrowerContract CreateBorrower(BorrowerContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var result = service.Create(new Borrower(contract));
                    return new Borrower().ConvertToContract(result, new BorrowerContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<Borrower, BorrowerContract>(exception);
            }
        }

        public BorrowedItemContract CreateBorrowedItem(BorrowedItemContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var result = service.Create(new BorrowedItem(contract));
                    return new BorrowedItem().ConvertToContract(result, new BorrowedItemContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowedItem, BorrowedItemContract>(exception);
            }
        }

        public BorrowerContract FetchBorrower(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var result = service.Get(id, includeDeletion);
                    return new Borrower().ConvertToContract(result, new BorrowerContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<Borrower, BorrowerContract>(exception);
            }
        }

        public BorrowedItemContract FetchBorrowedItem(int id, bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var result = service.Get(id, includeDeletion);
                    return new BorrowedItem().ConvertToContract(result, new BorrowedItemContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowedItem, BorrowedItemContract>(exception);
            }
        }

        public DomainListContract<BorrowerContract> FetchAllBorrowers(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new Borrower().ConvertToContract<Borrower, IEnumerable<Borrower>, BorrowerContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowerContract>(exception);
            }
        }

        public DomainListContract<BorrowedItemContract> FetchAllBorrowedItems(bool includeDeletion)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var result = service.GetAll(includeDeletion);
                    var returnResult = new BorrowedItem().ConvertToContract<BorrowedItem, IEnumerable<BorrowedItem>, BorrowedItemContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowedItemContract>(exception);
            }
        }

        public BorrowerContract SaveBorrower(BorrowerContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var result = service.Save(new Borrower(contract));
                    return new Borrower().ConvertToContract(result, new BorrowerContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<Borrower, BorrowerContract>(exception);
            }
        }

        public BorrowedItemContract SaveBorrowedItem(BorrowedItemContract contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var result = service.Save(new BorrowedItem(contract));
                    return new BorrowedItem().ConvertToContract(result, new BorrowedItemContract());
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowedItem, BorrowedItemContract>(exception);
            }
        }

        public DomainListContract<BorrowerContract> SaveAllBorrowers(DomainListContract<BorrowerContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var domainList = new Borrower().ConvertToDomain<Borrower, IEnumerable<Borrower>, BorrowerContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new Borrower().ConvertToContract<Borrower, IEnumerable<Borrower>, BorrowerContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowerContract>(exception);
            }
        }

        public DomainListContract<BorrowedItemContract> SaveAllBorrowedItems(DomainListContract<BorrowedItemContract> contract)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var domainList = new BorrowedItem().ConvertToDomain<BorrowedItem, IEnumerable<BorrowedItem>, BorrowedItemContract>(contract);
                    var result = service.SaveAll(domainList);
                    var returnResult = new BorrowedItem().ConvertToContract<BorrowedItem, IEnumerable<BorrowedItem>, BorrowedItemContract>(result);
                    return returnResult;
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse<BorrowedItemContract>(exception);
            }
        }

        public DomainStatusContract RemoveBorrower(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowerDal(context);
                    var process = new BorrowerProcess(provider);
                    var service = new BorrowerService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }

        public DomainStatusContract RemoveBorrowedItem(int id)
        {
            try
            {
                using (var context = new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString))
                {
                    var provider = new BorrowedItemDal(context);
                    var process = new BorrowedItemProcess(provider);
                    var service = new BorrowedItemService(process);

                    var result = service.Remove(id);
                    return DomainStatus.ConvertToContract(result);
                }

            }
            catch (Exception exception)
            {
                return HandleExceptionResponse(exception);
            }
        }
    }
}
