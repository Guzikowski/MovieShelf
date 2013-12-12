using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;


namespace Core_MovieShelf.Test.DomainTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class DomainMessageTest : AutoMockerBase<DomainMessage>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static DomainMessage CreateTargetObject()
        {
            return new DomainMessage();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IDomainMessage CreateTargetInterfaceObject()
        {
            IDomainMessage target = CreateTargetObject();
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

        
        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.DomainMessage";

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
