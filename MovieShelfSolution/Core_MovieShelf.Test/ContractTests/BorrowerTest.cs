using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class BorrowerTest : AutoMockerBase<BorrowerContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static BorrowerContract CreateTargetObject()
        {
            return new BorrowerContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IBorrowerContract CreateTargetInterfaceObject()
        {
            IBorrowerContract target = CreateTargetObject();
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
            Assert.IsNull(target.Email);

            CheckProperty(p => p.Email, null, null, UnitTestValues.LastName1);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceEmail()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNull(target.Email);

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
            Assert.IsNull(target.Phone);

            CheckProperty(p => p.Phone, null, null, UnitTestValues.LastName1);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfacePhone()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNull(target.Phone);

            target.Phone = UnitTestValues.LastName1;
            Assert.AreEqual(UnitTestValues.LastName1, target.Phone);
        }
    }
}
