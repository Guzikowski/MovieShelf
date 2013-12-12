using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Data;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Data;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Test.MockObjects;
using NUnit.Framework;
using Rhino.Mocks;

namespace Core_MovieShelf.Test.MockObjects
{
    /// <summary>
    /// TestBookCatalogService.Domain.MockHelper
    /// </summary>
    public partial class MockHelper
    {
        public IBaseEntityDal<Domain.BorrowedItem, IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>, int> GetBorrowedItemDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseEntityDal<Domain.BorrowedItem, IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetBorrowedItemEntity() as Domain.BorrowedItem);
            mock.Stub(x => x.ReadAll())
                .Return(GetBorrowedItemDomainListEntity());
            mock.Stub(x => x.Add(Arg<Domain.BorrowedItem>.Is.Anything))
                .Return(GetBorrowedItemEntity() as Domain.BorrowedItem);
            mock.Stub(x => x.Update(Arg<Domain.BorrowedItem>.Is.Anything))
                .Return(GetBorrowedItemEntity() as Domain.BorrowedItem);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        public IBaseEntityDal<Domain.BorrowedItem, IDomainList<Domain.BorrowedItem, IEnumerable<Domain.BorrowedItem>>, int> GetBorrowedItemDal()
        {
            return new BorrowedItemDal(GetContext());
        }
    }
}

namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class BorrowedItemDalTest : TestBase
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

        private static BorrowedItemDal GetClassUnderTest()
        {
            return new BorrowedItemDal(new MockHelper().GetContext());
        }

        private static Domain.BorrowedItem GetDomainEntity()
        {
            var result = new Domain.BorrowedItem
            {
                LastModifiedBy = "joe",
                LastModifiedDate = DateTime.Now,
                Name = "TestName",
                BorrowedBy = new Domain.Borrower
                {
                    Id = 1,
                    LastModifiedBy = "joe",
                    LastModifiedDate = DateTime.Now,
                },
                BorrowedMovie = new Domain.MovieDetail
                {
                    Id = 1,
                    LastModifiedBy = "joe",
                    LastModifiedDate = DateTime.Now,
                }
            };
            return result;
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
            var testDomainEntity = GetDomainEntity();
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.Add(testDomainEntity);

            Assert.IsNotNull(actualResult);
            Assert.Greater(actualResult.Id, 0);
        }
        [Test]
        public void TestReadAndUpdate()
        {
            var classUnderTest = GetClassUnderTest();
            var actualResult = classUnderTest.Read(1);

            Assert.IsNotNull(actualResult);

            const string checkValue = "I have changed this";
            actualResult.LastModifiedBy = checkValue;

            actualResult = classUnderTest.Update(actualResult);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.LastModifiedBy == checkValue);
        }
    }
}
