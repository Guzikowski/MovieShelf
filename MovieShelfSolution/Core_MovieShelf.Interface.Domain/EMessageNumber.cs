namespace Core_MovieShelf.Interface.Domain
{
    public enum EMessageNumber
    {
        NotInitialised = 0,
        ExceptionMessage = 1,

        ErrorLastModifiedByNotPresent = 100,
        ErrorLastModifiedByToLong,
        ErrorLastModifiedDateNotPresent,
        ErorrLastModifiedDateInFuture,
        ErrorNameNotPresent,
        ErrorNameToLong,
        ErrorContactDetailsNotPresent,
        ErrorPhoneToLong,
        ErrorEmailToLong,
        ErorrCollectedDateInFuture,
        ErorrInvalidBorrowedBy,
        ErorrInvalidBorrowedMovie,
        ErrorDateBorrowedNotPresent,
        ErorrDateBorrowedInFuture,
        ErorrDateOverdueMustBeInFuture,
        ErorrDateReturnedMustBeInFuture,
        ErorrInvalidDisplayImage,
        ErorrInvalidSeries,
        ErorrInvalidGenre,
        ErorrInvalidType,
        ErorrInvalidStatus,
        ErorrInvalidRating,
        ErorrInvalidViewRating,
        ErorrInvalidMonetaryValue,
        EntityListContainsErrors,
        DeletionErrorStillActive,
        DeletionErrorStillInUse,

        SuccessfulRead = 200,
        NoDataFound,
        SuccessfulAdd,
        SuccessfulUpdate,
        SuccessfulDelete,
        SuccessfulOperationCheck,
    }
}
