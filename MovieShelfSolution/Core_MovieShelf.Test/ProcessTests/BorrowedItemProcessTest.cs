
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Process;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ProcessTests
{
    [TestFixture]
    public class BorrowedItemProcessTest : TestBase
    {

        [TestFixtureSetUp]
        public void FixureSetup()
        {
            BaseDatabaseTestFixtureSetUp();
        }
        [SetUp]
        public void Setup()
        {
            BaseDatabaseTestSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            BaseDatabaseTestTearDown();
        }
        [TestFixtureTearDown]
        public void FixureTearDown()
        {
            BaseDatabaseTestFixtureTearDown();
        }

        private static BorrowedItemProcess GetClassUnderTest(IBaseEntityDal<Domain.BorrowedItem, IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>, int> provider)
        {
            return new BorrowedItemProcess(provider);
        }
        
        [Test]
        public void TestGet()
        {
            var dalInstance = new MockObjects.MockHelper().GetBorrowedItemDal();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.Get(1, true);

            Assert.IsNotNull(actualResult);

        }
        [Test]
        public void TestGetMock()
        {
            var dalInstance = new MockObjects.MockHelper().GetBorrowedItemDalGoodMock();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.Get(1, true);

            Assert.IsNotNull(actualResult);

        }
        [Test]
        public void TestGetAll()
        {
            var dalInstance = new MockObjects.MockHelper().GetBorrowedItemDal();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.GetAll(true);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.IsValid);
            Assert.IsTrue(actualResult.EntityList.Count() > 0);
        }
        [Test]
        public void TestGetAllMock()
        {
            var dalInstance = new MockObjects.MockHelper().GetBorrowedItemDalGoodMock();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.GetAll(true);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.IsValid);
            Assert.IsTrue(actualResult.EntityList.Count() > 0);
        }
        
    }
}
