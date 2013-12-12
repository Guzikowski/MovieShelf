using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class DomainMessageTest : AutoMockerBase<DomainMessageContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static DomainMessageContract CreateTargetObject()
        {
            return new DomainMessageContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IDomainMessageContract CreateTargetInterfaceObject()
        {
            IDomainMessageContract target = CreateTargetObject();
            return target;
        }
        #endregion

        [Test]
        [Category("version1.0")]
        public void TestId()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.Id);

            CheckProperty(p => p.Id, EMessageNumber.ErrorLastModifiedByNotPresent, EMessageNumber.NotInitialised, EMessageNumber.ErrorLastModifiedDateNotPresent);
        }
        /// <summary>
        /// Tests the interface id.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceId()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.Id);

            target.Id = EMessageNumber.ErrorLastModifiedByToLong;
            Assert.AreEqual(EMessageNumber.ErrorLastModifiedByToLong, target.Id);
        }
        [Test]
        [Category("version1.0")]
        public void TestType()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target.Type);

            CheckProperty(p => p.Type, EMessageType.All, EMessageType.All, EMessageType.Error);
        }
        /// <summary>
        /// Tests the interface id.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceType()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target.Type);

            target.Type = EMessageType.Information;
            Assert.AreEqual(EMessageType.Information, target.Type);
        }

        [Test]
        [Category("version1.0")]
        public void TestMessage()
        {
            var target = CreateTargetObject();
            Assert.IsNull(target.Message);

            CheckProperty(p => p.Message, string.Empty, null, "Here be da message for all da messages");
        }
        /// <summary>
        /// Tests the interface id.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceMessage()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNull(target.Message);

            target.Message = "Here be da message for all da messages";
            Assert.AreEqual("Here be da message for all da messages", target.Message);
        }
    }
}
