using System;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBorrowedItem
    /// </summary>
    public interface IBorrowedItemContract :IBaseEntityContract
    {
        IBorrowerContract BorrowedBy { get; }
        IMovieDetailContract BorrowedMovie { get; }
        DateTime DateBorrowed { get; set; }
        DateTime DateOverdue { get; set; }
        DateTime? DateReturned { get; set; }
    }
}
