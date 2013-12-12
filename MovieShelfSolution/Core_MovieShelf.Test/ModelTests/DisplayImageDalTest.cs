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
        public IBaseDal<Domain.DisplayImage, IDomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>>, int> GetDisplayImageDalGoodMock()
        {
            var mock = MockRepository.GenerateStub<IBaseDal<Domain.DisplayImage, IDomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>>, int>>();
            mock.Stub(x => x.Read(Arg<int>.Is.Anything))
                .Return(GetDisplayImageEntity() as Domain.DisplayImage);
            mock.Stub(x => x.ReadAll())
                .Return(GetDisplayImageDomainListEntity());
            mock.Stub(x => x.Add(Arg<Domain.DisplayImage>.Is.Anything))
                .Return(GetDisplayImageEntity() as Domain.DisplayImage);
            mock.Stub(x => x.Update(Arg<Domain.DisplayImage>.Is.Anything))
                .Return(GetDisplayImageEntity() as Domain.DisplayImage);
            mock.Stub(x => x.Delete(Arg<int>.Is.Anything))
               .Return(new DomainStatus());
            return mock;
        }
        public IBaseDal<Domain.DisplayImage, IDomainList<Domain.DisplayImage, IEnumerable<Domain.DisplayImage>>, int> GetDisplayImageDal()
        {
            return new DisplayImageDal(GetContext());
        }
    }
}

namespace Core_MovieShelf.Test.ModelTests
{
    [TestFixture]
    public class DisplayImageDalTest : TestBase
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
        private static DisplayImageDal GetClassUnderTest()
        {
            return new DisplayImageDal((new MockHelper()).GetContext());
        }
        private static Domain.DisplayImage GetDomainEntity()
        {
            var result = new Domain.DisplayImage
            {
                LastModifiedBy = "joe",
                LastModifiedDate = DateTime.Now,
                Path = "C:\temp\test.png",
                Name = "TestName",
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
            actualResult.Name = checkValue;

            actualResult = classUnderTest.Update(actualResult);

            Assert.IsNotNull(actualResult);
            Assert.IsTrue(actualResult.Name == checkValue);
        }
    }
}
