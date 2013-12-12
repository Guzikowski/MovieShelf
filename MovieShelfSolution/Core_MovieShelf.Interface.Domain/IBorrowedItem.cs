using System;

namespace Core_MovieShelf.Interface.Domain
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBorrowedItem
    /// </summary>
    public interface IBorrowedItem :IBaseEntity
    {
        IBorrower BorrowedBy { get; }
        IMovieDetail BorrowedMovie { get; }
        DateTime DateBorrowed { get; set; }
        DateTime DateOverdue { get; set; }
        DateTime? DateReturned { get; set; }
    }
}
