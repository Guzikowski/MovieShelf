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
        public IBaseLookupDal<Domain.MovieType, IDomainList<Domain.MovieType, IEnumerable<Domain.MovieType>>, int> GetMovieTypeDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseLookupDal<Domain.MovieType, IDomainList<Domain.MovieType, IEnumerable<Domain.MovieType>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetMovieTypeEntity() as Domain.MovieType);
            mock.Stub(x => x.ReadAll())
                .Return(GetMovieTypeDomainListEntity());
            mock.Stub(x => x.Add(Arg<Domain.MovieType>.Is.Anything))
                .Return(GetMovieTypeEntity() as Domain.MovieType);
            mock.Stub(x => x.Update(Arg<Domain.MovieType>.Is.Anything))
                .Return(GetMovieTypeEntity() as Domain.MovieType);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
                .Return(new DomainStatus());
            return mock;
        }
        public IBaseLookupDal<Domain.MovieType, IDomainList<Domain.MovieType, IEnumerable<Domain.MovieType>>, int> GetMovieTypeDal()
        {
            return new MovieTypeDal(GetContext());
        }
    }
}


namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class MovieTypeDalTest : TestBase
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

      
        private static MovieTypeDal GetClassUnderTest()
        {
            return new MovieTypeDal(new MockHelper().GetContext());
        }
        private static Domain.MovieType GetDomainEntity()
        {
            var result = new Domain.MovieType
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
