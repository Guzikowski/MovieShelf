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
        public IBaseLookupDal<Domain.GenreType, IDomainList<Domain.GenreType, IEnumerable<Domain.GenreType>>, int> GetGenreTypeDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseLookupDal<Domain.GenreType, IDomainList<Domain.GenreType, IEnumerable<Domain.GenreType>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetGenreTypeEntity() as Domain.GenreType);
            mock.Stub(x => x.ReadAll())
                .Return(GetGenreTypeDomainListEntity());
            mock.Stub(x => x.Add(Arg<Domain.GenreType>.Is.Anything))
                .Return(GetGenreTypeEntity() as Domain.GenreType);
            mock.Stub(x => x.Update(Arg<Domain.GenreType>.Is.Anything))
                .Return(GetGenreTypeEntity() as Domain.GenreType);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        public IBaseLookupDal<Domain.GenreType, IDomainList<Domain.GenreType, IEnumerable<Domain.GenreType>>, int> GetGenreTypeDal()
        {
            return new GenreTypeDal(GetContext());
        }
    }
}


namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class GenreTypeDalTest : TestBase
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

        private static GenreTypeDal GetClassUnderTest()
        {
            return new GenreTypeDal(new MockHelper().GetContext());
        }
        private static Domain.GenreType GetDomainEntity()
        {
            var result = new Domain.GenreType
            {
                LastModifiedBy = "joe",
                LastModifiedDate = DateTime.Now,
                Name = "TestName",
                DisplayImage = new Domain.DisplayImage
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
