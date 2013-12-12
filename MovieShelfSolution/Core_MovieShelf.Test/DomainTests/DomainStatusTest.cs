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
    public class DomainStatusTest : AutoMockerBase<DomainStatus>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static DomainStatus CreateTargetObject()
        {
            return new DomainStatus();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IDomainStatus CreateTargetInterfaceObject()
        {
            IDomainStatus target = CreateTargetObject();
            return target;
        }
        #endregion

        [Test]
        public void AddMessageTest()
        {
            var classUnderTest = CreateTargetObject();
            Assert.IsNotNull(classUnderTest);
            Assert.IsNotNull(classUnderTest.Messages);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

            var expectedResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong);
            classUnderTest.AddMessage(expectedResult);

            Assert.IsTrue(classUnderTest.Messages.Count == 1);

        }

        [Test]
        public void AddMessageDuplicateTest()
        {
            var classUnderTest = CreateTargetObject();
            Assert.IsNotNull(classUnderTest);
            Assert.IsNotNull(classUnderTest.Messages);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

            var expectedResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong);
            classUnderTest.AddMessage(expectedResult);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);

            classUnderTest.AddMessage(expectedResult);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);

        }

        [Test]
        public void GetMessageTest()
        {
            var classUnderTest = CreateTargetObject();
            Assert.IsNotNull(classUnderTest);
            Assert.IsNotNull(classUnderTest.Messages);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

            var expectedResult =  MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong);
            classUnderTest.AddMessage(expectedResult);

            Assert.IsTrue(classUnderTest.Messages.Count == 1);

            var actualResult = classUnderTest.GetMessages(EMessageType.All);
            Assert.IsTrue(actualResult.Count == 1);
            Assert.IsTrue(actualResult[0].Id == expectedResult.Id);

            actualResult = classUnderTest.GetMessages(EMessageType.Error);
            Assert.IsTrue(actualResult.Count == 1);
            Assert.IsTrue(actualResult[0].Id == expectedResult.Id);

            actualResult = classUnderTest.GetMessages(EMessageType.Information);
            Assert.IsTrue(actualResult.Count == 0);

            actualResult = classUnderTest.GetMessages(EMessageType.Warning);
            Assert.IsTrue(actualResult.Count == 0);

        }

        [Test]
        public void ClearMessageTest()
        {
            var classUnderTest = CreateTargetObject();
            Assert.IsNotNull(classUnderTest);
            Assert.IsNotNull(classUnderTest.Messages);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

            var expectedResult = MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong);
            classUnderTest.AddMessage(expectedResult);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);
            classUnderTest.ClearMessages(EMessageType.Information);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);
            classUnderTest.ClearMessages(EMessageType.All);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

            classUnderTest.AddMessage(expectedResult);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);
            classUnderTest.ClearMessages(EMessageType.Warning);
            Assert.IsTrue(classUnderTest.Messages.Count == 1);
            classUnderTest.ClearMessages(EMessageType.Error);
            Assert.IsTrue(classUnderTest.Messages.Count == 0);

        }
        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.DomainStatus";

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
