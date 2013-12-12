using System;
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


namespace Core_MovieShelf.Test.MockObjects
{
    /// <summary>
    /// TestBookCatalogService.Domain.MockHelper
    /// </summary>
    public partial class MockHelper
    {
        public IBaseEntityDal<Domain.MovieDetail, IDomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>>, int> GetMovieDetailDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseEntityDal<Domain.MovieDetail, IDomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetMovieDetailEntity() as Domain.MovieDetail);
            mock.Stub(x => x.ReadAll())
                .Return(GetMovieDetailDomainListEntity());
            mock.Stub(x => x.Add(Arg<Domain.MovieDetail>.Is.Anything))
                .Return(GetMovieDetailEntity() as Domain.MovieDetail);
            mock.Stub(x => x.Update(Arg<Domain.MovieDetail>.Is.Anything))
                .Return(GetMovieDetailEntity() as Domain.MovieDetail);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        public MovieShelfEntities GetContext()
        {
            return new MovieShelfEntities(ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString);
        }
        public IBaseEntityDal<Domain.MovieDetail, IDomainList<Domain.MovieDetail, IEnumerable<Domain.MovieDetail>>, int> GetMovieDetailDal()
        {
            return new MovieDetailDal(GetContext());
        }
    }
}

namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class MovieDetailDalTest : TestBase
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

        
        private static MovieDetailDal GetClassUnderTest()
        {
            return new MovieDetailDal(new MockHelper().GetContext());
        }
        private static Domain.MovieDetail GetDomainEntity()
        {
            var result = new Domain.MovieDetail
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
