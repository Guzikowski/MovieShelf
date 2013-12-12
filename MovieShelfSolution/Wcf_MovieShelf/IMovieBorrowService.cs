using System.ServiceModel;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Wcf_MovieShelf
{
    [ServiceContract]
    public interface IMovieBorrowService
    {
        [OperationContract]
        string HelloService(string greeting);

        [OperationContract]
        BorrowerContract CreateBorrower(BorrowerContract contract);

        [OperationContract]
        BorrowedItemContract CreateBorrowedItem(BorrowedItemContract contract);

        [OperationContract]
        BorrowerContract FetchBorrower(int id, bool includeDeletion);

        [OperationContract]
        BorrowedItemContract FetchBorrowedItem(int id, bool includeDeletion);

        [OperationContract]
        DomainListContract<BorrowerContract> FetchAllBorrowers(bool includeDeletion);

        [OperationContract]
        DomainListContract<BorrowedItemContract> FetchAllBorrowedItems(bool includeDeletion);

        [OperationContract]
        BorrowerContract SaveBorrower(BorrowerContract contract);

        [OperationContract]
        BorrowedItemContract SaveBorrowedItem(BorrowedItemContract contract);

        [OperationContract]
        DomainListContract<BorrowerContract> SaveAllBorrowers(DomainListContract<BorrowerContract> contract);

        [OperationContract]
        DomainListContract<BorrowedItemContract> SaveAllBorrowedItems(DomainListContract<BorrowedItemContract> contract);

        [OperationContract]
        DomainStatusContract RemoveBorrower(int id);

        [OperationContract]
        DomainStatusContract RemoveBorrowedItem(int id);


    }
}
