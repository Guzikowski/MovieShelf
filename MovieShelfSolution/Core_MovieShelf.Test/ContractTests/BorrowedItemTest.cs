using System;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class BorroweredItemTest : AutoMockerBase<BorrowedItemContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static BorrowedItemContract CreateTargetObject()
        {
            return new BorrowedItemContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IBorrowedItemContract CreateTargetInterfaceObject()
        {
            IBorrowedItemContract target = CreateTargetObject();
            return target;
        }
        #endregion
        [Test]
        [Category("version1.0")]
        public void TestDateBorrowed()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.DateBorrowed);

            CheckProperty(p => p.DateBorrowed, DateTime.MinValue, DateTime.MinValue, DateTime.Now);
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

            CheckProperty(p => p.DateOverdue, DateTime.MinValue, DateTime.MinValue, DateTime.Now);
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
    
    }
}
