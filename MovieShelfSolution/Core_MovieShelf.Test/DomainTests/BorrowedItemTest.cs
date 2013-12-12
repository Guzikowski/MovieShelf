
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
        public IDomainList<BorrowedItem, IEnumerable<BorrowedItem>> GetBorrowedItemDomainListEntity()
        {
            var result = new DomainList<BorrowedItem, IEnumerable<BorrowedItem>>
            {
                EntityList = GetBorrowedItemListEntity()
            };
            result.Validate();
            return result;
        }
        public IList<BorrowedItem> GetBorrowedItemListEntity()
        {
            var result = new List<BorrowedItem>
            {
                GetBorrowedItemEntity() as BorrowedItem,
                GetBorrowedItemEntity() as BorrowedItem,
                GetBorrowedItemEntity() as BorrowedItem
            };
            return result;
        }

        public IBorrowedItem GetBorrowedItemEntity()
        {
            var result = new BorrowedItem
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
    public class BorroweredItemTest : AutoMockerBase<BorrowedItem>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static BorrowedItem CreateTargetObject()
        {
            return new BorrowedItem();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IBorrowedItem CreateTargetInterfaceObject()
        {
            IBorrowedItem target = CreateTargetObject();
            return target;
        }
        #endregion

        [Test]
        [Category("version1.0")]
        public void TestDateBorrowed()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.DateBorrowed);

            CheckProperty(p => p.DateBorrowed, DateTime.MinValue, DateTime.Now, DateTime.MaxValue);
        }

        [Test]
        [Category("version1.0")]
        public void TestInterfaceDateBorrowed()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.DateBorrowed);

            target.DateBorrowed = DateTime.Now.Date;
            Assert.AreEqual(DateTime.Now.Date, target.DateBorrowed);
        }
        [Test]
        [Category("version1.0")]
        public void TestDateOverdue()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.DateOverdue);

            CheckProperty(p => p.DateOverdue, DateTime.MinValue, DateTime.Now, DateTime.Now);
        }

        [Test]
        [Category("version1.0")]
        public void TestInterfaceDateOverdue()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.DateOverdue);

            target.DateOverdue = DateTime.Now.Date;
            Assert.AreEqual(DateTime.Now.Date, target.DateOverdue);
        }
        [Test]
        [Category("version1.0")]
        public void TestDateReturned()
        {
            var target = CreateTargetObject();
            Assert.IsNull(target.DateReturned);

            CheckProperty(p => p.DateReturned, DateTime.MinValue, null, DateTime.Now);
        }

        [Test]
        [Category("version1.0")]
        public void TestInterfaceDateReturned()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNull(target.DateReturned);

            target.DateReturned = DateTime.Now.Date;
            Assert.AreEqual(DateTime.Now.Date, target.DateReturned);
        }

        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.BorrowedItem";

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
