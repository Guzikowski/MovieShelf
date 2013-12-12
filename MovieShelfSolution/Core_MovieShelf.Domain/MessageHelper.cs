using System.Collections.Generic;
using Core_MovieShelf.Interface.Domain;


namespace Core_MovieShelf.Domain
{
    public static class MessageHelper
    {
        private static readonly Dictionary<EMessageNumber, IDomainMessage> RegisteredMessages = new Dictionary<EMessageNumber, IDomainMessage>();

        static MessageHelper()
        {
            RegisteredMessages.Add(EMessageNumber.ErrorLastModifiedByNotPresent, new DomainMessage { Id = EMessageNumber.ErrorLastModifiedByNotPresent, Type = EMessageType.Error, Message = "ValidationError: LastModifiedBy must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErrorLastModifiedByToLong, new DomainMessage { Id = EMessageNumber.ErrorLastModifiedByToLong, Type = EMessageType.Error, Message = "ValidationError: LastModifiedBy is to long" });
            RegisteredMessages.Add(EMessageNumber.ErrorLastModifiedDateNotPresent, new DomainMessage { Id = EMessageNumber.ErrorLastModifiedDateNotPresent, Type = EMessageType.Error, Message = "ValidationError: LastModifiedDate must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErorrLastModifiedDateInFuture, new DomainMessage { Id = EMessageNumber.ErorrLastModifiedDateInFuture, Type = EMessageType.Error, Message = "ValidationError: LastModifiedDate must not be in the future" });
            RegisteredMessages.Add(EMessageNumber.ErrorNameNotPresent, new DomainMessage { Id = EMessageNumber.ErrorNameNotPresent, Type = EMessageType.Error, Message = "ValidationError: Name must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErrorNameToLong, new DomainMessage { Id = EMessageNumber.ErrorNameToLong, Type = EMessageType.Error, Message = "ValidationError: Name is to long" });
            RegisteredMessages.Add(EMessageNumber.ErrorContactDetailsNotPresent, new DomainMessage { Id = EMessageNumber.ErrorContactDetailsNotPresent, Type = EMessageType.Error, Message = "ValidationError: Email or Phone must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErrorPhoneToLong, new DomainMessage { Id = EMessageNumber.ErrorPhoneToLong, Type = EMessageType.Error, Message = "ValidationError: Phone is to long" });
            RegisteredMessages.Add(EMessageNumber.ErrorEmailToLong, new DomainMessage { Id = EMessageNumber.ErrorEmailToLong, Type = EMessageType.Error, Message = "ValidationError: Email is to long" });
            RegisteredMessages.Add(EMessageNumber.ErorrCollectedDateInFuture, new DomainMessage { Id = EMessageNumber.ErorrCollectedDateInFuture, Type = EMessageType.Error, Message = "ValidationError: Collected Date must not be in the future" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidBorrowedBy, new DomainMessage { Id = EMessageNumber.ErorrInvalidBorrowedBy, Type = EMessageType.Error, Message = "ValidationError: Borrowed By must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidBorrowedMovie, new DomainMessage { Id = EMessageNumber.ErorrInvalidBorrowedMovie, Type = EMessageType.Error, Message = "ValidationError: Borrowed Movie must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErrorDateBorrowedNotPresent, new DomainMessage { Id = EMessageNumber.ErrorDateBorrowedNotPresent, Type = EMessageType.Error, Message = "ValidationError: Date Borrowed must have a value" });
            RegisteredMessages.Add(EMessageNumber.ErorrDateBorrowedInFuture, new DomainMessage { Id = EMessageNumber.ErorrDateBorrowedInFuture, Type = EMessageType.Error, Message = "ValidationError: Date Borrowed must not be in the future" });
            RegisteredMessages.Add(EMessageNumber.ErorrDateOverdueMustBeInFuture, new DomainMessage { Id = EMessageNumber.ErorrDateOverdueMustBeInFuture, Type = EMessageType.Error, Message = "ValidationError: Date Overdue must not be in the future" });
            RegisteredMessages.Add(EMessageNumber.ErorrDateReturnedMustBeInFuture, new DomainMessage { Id = EMessageNumber.ErorrDateReturnedMustBeInFuture, Type = EMessageType.Error, Message = "ValidationError: Date Returned must not be in the future" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidDisplayImage, new DomainMessage { Id = EMessageNumber.ErorrInvalidDisplayImage, Type = EMessageType.Error, Message = "ValidationError: Display Image must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidSeries, new DomainMessage { Id = EMessageNumber.ErorrInvalidSeries, Type = EMessageType.Error, Message = "ValidationError: Movie Series must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidGenre, new DomainMessage { Id = EMessageNumber.ErorrInvalidGenre, Type = EMessageType.Error, Message = "ValidationError: Movie Genre must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidType, new DomainMessage { Id = EMessageNumber.ErorrInvalidType, Type = EMessageType.Error, Message = "ValidationError: Movie Type must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidStatus, new DomainMessage { Id = EMessageNumber.ErorrInvalidStatus, Type = EMessageType.Error, Message = "ValidationError: Movie Status must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidRating, new DomainMessage { Id = EMessageNumber.ErorrInvalidRating, Type = EMessageType.Error, Message = "ValidationError: Movie Rating must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidViewRating, new DomainMessage { Id = EMessageNumber.ErorrInvalidViewRating, Type = EMessageType.Error, Message = "ValidationError: Movie View Rating must have a valid existing value" });
            RegisteredMessages.Add(EMessageNumber.ErorrInvalidMonetaryValue, new DomainMessage { Id = EMessageNumber.ErorrInvalidMonetaryValue, Type = EMessageType.Error, Message = "ValidationError: Monetary value must be within 0-200 range" });
            RegisteredMessages.Add(EMessageNumber.EntityListContainsErrors, new DomainMessage { Id = EMessageNumber.EntityListContainsErrors, Type = EMessageType.Error, Message = "ValidationError: Collection contains errors" });
            RegisteredMessages.Add(EMessageNumber.DeletionErrorStillActive, new DomainMessage { Id = EMessageNumber.DeletionErrorStillActive, Type = EMessageType.Error, Message = "DeletionError: Item needs to be removed prior to deletion" });
            RegisteredMessages.Add(EMessageNumber.DeletionErrorStillInUse, new DomainMessage { Id = EMessageNumber.DeletionErrorStillInUse, Type = EMessageType.Error, Message = "DeletionError: Item needs to have all references removed prior to deletion" });

            
            RegisteredMessages.Add(EMessageNumber.SuccessfulRead, new DomainMessage { Id = EMessageNumber.SuccessfulRead, Type = EMessageType.Information, Message = "Reponse: Successfully read from the database" });
            RegisteredMessages.Add(EMessageNumber.NoDataFound, new DomainMessage { Id = EMessageNumber.NoDataFound, Type = EMessageType.Information, Message = "Reponse: No Data Found for the query" });
            RegisteredMessages.Add(EMessageNumber.SuccessfulAdd, new DomainMessage { Id = EMessageNumber.SuccessfulAdd, Type = EMessageType.Information, Message = "Reponse: Successfully added to the database" });
            RegisteredMessages.Add(EMessageNumber.SuccessfulUpdate, new DomainMessage { Id = EMessageNumber.SuccessfulUpdate, Type = EMessageType.Information, Message = "Reponse: Successfully updated to the database" });
            RegisteredMessages.Add(EMessageNumber.SuccessfulDelete, new DomainMessage { Id = EMessageNumber.SuccessfulDelete, Type = EMessageType.Information, Message = "Reponse: Successfully deleted from the database" });
            RegisteredMessages.Add(EMessageNumber.SuccessfulOperationCheck, new DomainMessage { Id = EMessageNumber.SuccessfulOperationCheck, Type = EMessageType.Information, Message = "Reponse: Successfully execution of operation check" });

        }

        public static IDomainMessage Get(EMessageNumber number)
        {
            IDomainMessage result = new DomainMessage();
            if (!RegisteredMessages.ContainsKey(number))
            {
                return result;
            }
            if (!RegisteredMessages.TryGetValue(number, out result))
            {
                result = new DomainMessage();   
            }
            return result;
        }
    }
}