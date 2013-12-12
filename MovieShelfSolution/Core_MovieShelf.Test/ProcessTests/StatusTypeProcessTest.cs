using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Process;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ProcessTests
{
    [TestFixture]
    public class StatusTypeProcessTest : TestBase
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
        
        private static StatusTypeProcess GetClassUnderTest(IBaseLookupDal<Domain.StatusType, IDomainList<Domain.StatusType,IEnumerable<Domain.StatusType>>, int> provider)
        {
            return new StatusTypeProcess(provider);
        }
        
        [Test]
        public void TestGet()
        {
            var dalInstance = new MockObjects.MockHelper().GetStatusTypeDal();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.Get(1, true);

            Assert.IsNotNull(actualResult);

        }
        [Test]
        public void TestGetMock()
        {
            var dalInstance = new MockObjects.MockHelper().GetStatusTypeDalGoodMock();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.Get(1, true);

            Assert.IsNotNull(actualResult);

        }
        [Test]
        public void TestGetAll()
        {
            var dalInstance = new MockObjects.MockHelper().GetStatusTypeDal();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.GetAll(true);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.IsValid);
            Assert.IsTrue(actualResult.EntityList.Count() > 0);
        }
        [Test]
        public void TestGetAllMock()
        {
            var dalInstance = new MockObjects.MockHelper().GetStatusTypeDalGoodMock();
            var classUnderTest = GetClassUnderTest(dalInstance);
            var actualResult = classUnderTest.GetAll(true);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.IsValid);
            Assert.IsTrue(actualResult.EntityList.Count() > 0);
        }
      
    }
}
