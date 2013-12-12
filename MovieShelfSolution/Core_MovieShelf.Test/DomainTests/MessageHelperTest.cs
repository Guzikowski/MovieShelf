using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using NUnit.Framework;


namespace Core_MovieShelf.Test.DomainTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class MessageHelperTest
    {
        [Test]
        public void GetTest()
        {
            var actualResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong);
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Id == EMessageNumber.ErrorLastModifiedByToLong);

            actualResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedDateNotPresent);
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Id == EMessageNumber.ErrorLastModifiedDateNotPresent);

            actualResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedByNotPresent);
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Id == EMessageNumber.ErrorLastModifiedByNotPresent);

            actualResult = MessageHelper.Get(EMessageNumber.ErorrLastModifiedDateInFuture);
            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Id == EMessageNumber.ErorrLastModifiedDateInFuture);
        }


    }
}
