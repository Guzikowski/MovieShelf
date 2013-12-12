using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Core_MovieShelf.Data;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Test.MockObjects;
using NUnit.Framework;
using Rhino.Mocks;
using StatusType = Core_MovieShelf.Domain.StatusType;

namespace Core_MovieShelf.Test.MockObjects
{
    /// <summary>
    /// TestBookCatalogService.Domain.MockHelper
    /// </summary>
    public partial class MockHelper
    {
        public IBaseLookupDal<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int> GetStatusTypeDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseLookupDal<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetStatusTypeEntity() as StatusType);
            mock.Stub(x => x.ReadAll())
                .Return(GetStatusTypeDomainListEntity());
            mock.Stub(x => x.Add(Arg<StatusType>.Is.Anything))
                .Return(GetStatusTypeEntity() as StatusType);
            mock.Stub(x => x.Update(Arg<StatusType>.Is.Anything))
                .Return(GetStatusTypeEntity() as StatusType);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        
        public IBaseLookupDal<StatusType, IDomainList<StatusType, IEnumerable<StatusType>>, int> GetStatusTypeDal()
        {
            return new StatusTypeDal(GetContext());
        }
    }
}


namespace Core_MovieShelf.Test.ModelTests
{

    [TestFixture]
    public class StatusTypeDalTest : TestBase
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

        
        private static StatusTypeDal GetClassUnderTest()
        {
            return new StatusTypeDal(new MockHelper().GetContext());
        }
        
        [Test]
        public void TestRead()
        {
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.Read(1);

            Assert.IsNotNull(actualResult);

        }

        [Test]
        public void TestReadAll()
        {
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.ReadAll();

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.EntityList.Count() > 0);
        }
        [Test]
        public void TestAdd()
        {
            var testDomainEntity = new MockObjects.MockHelper().GetStatusTypeEntity();
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.Add(testDomainEntity as Domain.StatusType);

            Assert.IsNotNull(actualResult);
            Assert.Greater(actualResult.Id, 0);
            Assert.IsNotNull(actualResult.DisplayImage);
            Assert.Greater(actualResult.DisplayImage.Id, 0);
        }
        [Test]
        public void TestReadAndUpdate()
        {
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.Read(1);

            Assert.IsNotNull(actualResult);

            const string checkValue = "I have changed this";
            actualResult.Name = checkValue;

            actualResult = classUnderTest.Update(actualResult);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Name == checkValue);
        }
    }
}
