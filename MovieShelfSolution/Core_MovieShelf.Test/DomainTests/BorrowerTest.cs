
using System;
using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

namespace Core_MovieShelf.Test.MockObjects
{
    /// <summary>
    /// TestBookCatalogService.Domain.MockHelper
    /// </summary>
    public partial class MockHelper
    {
        public IDomainList<Borrower, IEnumerable<Borrower>> GetBorrowerDomainListEntity()
        {
            var result = new DomainList<Borrower, IEnumerable<Borrower>>
            {
                EntityList = GetBorrowerListEntity()
            };
            result.Validate();
            return result;
        }
        public IList<Borrower> GetBorrowerListEntity()
        {
            var result = new List<Borrower>
            {
                GetBorrowerEntity() as Borrower,
                GetBorrowerEntity() as Borrower,
                GetBorrowerEntity() as Borrower
            };
            return result;
        }

        public IBorrower GetBorrowerEntity()
        {
            var result = new Borrower
            {
                LastModifiedBy = "joe",
                LastModifiedDate = DateTime.Now,
                Name = "TestName",
                DisplayImage = GetDisplayImageEntity()
            };
            return result;
        }
    }
}

namespace Core_MovieShelf.Test.DomainTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class BorrowerTest : AutoMockerBase<Borrower>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static Borrower CreateTargetObject()
        {
            return new Borrower();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IBorrower CreateTargetInterfaceObject()
        {
            IBorrower target = CreateTargetObject();
            return target;
        }
        #endregion

        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestEmail()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.Email);

            CheckProperty(p => p.Email, string.Empty, string.Empty, UnitTestValues.LastName1);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceEmail()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.Email);

            target.Email = UnitTestValues.LastName1;
            Assert.AreEqual(UnitTestValues.LastName1, target.Email);
        }
        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestPhone()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.Phone);

            CheckProperty(p => p.Phone, string.Empty, string.Empty, UnitTestValues.LastName1);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfacePhone()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.Phone);

            target.Phone = UnitTestValues.LastName1;
            Assert.AreEqual(UnitTestValues.LastName1, target.Phone);
        }


        [Test]
        [Category("version1.0")]
        public void TestIsValid()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target);

            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.Name = "testName";

            target.Phone = "testName";
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.Id = 1;
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.LastModifiedBy = "testUser";
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.Phone = "1234567890123456789012345678901234567890";
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.Phone = "1234567890";
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.Phone = "";
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.Email = "testName";
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.Email = "1234567890123456789012345678901234567890";
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.Email = "1234567890";
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.Email = "";
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

        }

        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.Borrower";

            private readonly MSPrivateObject _mmsPrivateObject;
            private static readonly MSPrivateType MmsPrivateType = new MSPrivateType(FileName, FullClassName);

            /// <summary>
            /// Initializes a new instance of the <see cref="PrivateAccessor"/> class.
            /// </summary>
            /// <param name="target">The target.</param>
            public PrivateAccessor(object target)
            {
                _mmsPrivateObject = new MSPrivateObject(target, MmsPrivateType);
            }

            /// <summary>
            /// Creates the private.
            /// </summary>
            /// <returns></returns>
            public static object CreatePrivate()
            {
                var privObj = new MSPrivateObject(FileName, FullClassName);
                return privObj.Target;
            }
            /// <summary>
            /// Gets the MMS private object.
            /// </summary>
            /// <value>The MMS private object.</value>
            public MSPrivateObject MmsPrivateObject
            {
                get { return _mmsPrivateObject; }
            }



        }
        #endregion
    }
}
