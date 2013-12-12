
using System.Configuration;


namespace Core_MovieShelf.Test
{
    public class UnitTestValues
    {
        #region Database Parameters

        public static readonly string ServerName = ConfigurationManager.AppSettings["DatabaseServerName"];
        public static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
        public static readonly string UnitTesterUserName = ConfigurationManager.AppSettings["UnitTesterUserName"];
        public static readonly string UnitTesterPassword = ConfigurationManager.AppSettings["UnitTesterPassword"];

        #endregion

        #region Borrower Parameters
        public const string FirstName1 = "John";
        public const string LastName1 = "Doe";
        public const string FirstName2 = "Thomas";
        public const string LastName2 = "Harris";
        #endregion
        #region Movie Parameters
        public const string MovieType = "BluRay";
        public const string GenreType = "Sci-Fi";
        public const string RatingType = "R";
        public const string ViewRatingType = "Great";
        public const string StatusType = "Purchased";
        public const string Series = "The Chronicles of Timelessness";
        public const string Title = "Four Minutes Past Yesterday";
        public const string ISBN = "123-1223121-000";
        #endregion
        #region Common Parameters
        public const int Id = 1;
        public static readonly byte[] TimestampBegin = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7B };
        public static readonly byte[] TimestampEnd = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x03, 0x1E };
        #endregion
    }
}
