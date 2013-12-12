using System;
using System.Runtime.Serialization;

namespace Core_MovieShelf.Interface.Domain.Contracts
{
    /// <summary>
    /// Core_MovieShelf.Interface.Domain.IBorrowedItem
    /// </summary>
    [DataContract]
    public class BorrowedItemContract : BaseEntityContract, IBorrowedItemContract
    {
        [DataMember]
        public IBorrowerContract BorrowedBy { get; set; }
        [DataMember]
        public IMovieDetailContract BorrowedMovie { get; set;  }
        [DataMember]
        public DateTime DateBorrowed { get; set; }
        [DataMember]
        public DateTime DateOverdue { get; set; }
        [DataMember]
        public DateTime? DateReturned { get; set; }
    }
}
