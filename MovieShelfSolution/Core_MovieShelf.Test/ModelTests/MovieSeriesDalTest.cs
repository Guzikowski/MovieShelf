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
        public IBaseEntityDal<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int> GetMovieSeriesDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseEntityDal<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetMovieSeriesEntity() as MovieSeries);
            mock.Stub(x => x.ReadAll())
                .Return(GetMovieSeriesDomainListEntity());
            mock.Stub(x => x.Add(Arg<MovieSeries>.Is.Anything))
                .Return(GetMovieSeriesEntity() as MovieSeries);
            mock.Stub(x => x.Update(Arg<MovieSeries>.Is.Anything))
                .Return(GetMovieSeriesEntity() as MovieSeries);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        public IBaseEntityDal<MovieSeries, IDomainList<MovieSeries, IEnumerable<MovieSeries>>, int> GetMovieSeriesDal()
        {
            return new MovieSeriesDal(GetContext());
        }
    }
}

namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class MovieSeriesDalTest : TestBase
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

        private static MovieSeriesDal GetClassUnderTest()
        {
            return new MovieSeriesDal(new MockHelper().GetContext());
        }
        private static Domain.MovieSeries GetDomainEntity()
        {
            var result = new Domain.MovieSeries
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
