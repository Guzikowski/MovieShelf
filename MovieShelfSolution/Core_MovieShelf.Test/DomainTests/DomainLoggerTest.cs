using System;
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
        
        
    }
}

namespace Core_MovieShelf.Test.DomainTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.MovieTest
    /// </summary>
    [TestFixture]
    public class DomainLoggerTest : AutoMockerBase<DomainLogger>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static DomainLogger CreateTargetObject()
        {
            return new DomainLogger();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IDomainLogger CreateTargetInterfaceObject()
        {
            IDomainLogger target = CreateTargetObject();
            return target;
        }
        #endregion

        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestLogMessage()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target);

            target.LogMessage("This is a Test for LogMessage interface");
            
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceLogMessage()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target);

            target.LogMessage("This is a Test for LogMessage interface");
        }
        /// <summary>
        /// Tests the name.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestLogException()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target);

            var ex = new Exception("This is a Test for LogException");
            target.LogException(ex);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceLogException()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target);

            var ex = new Exception("This is a Test for LogException");
            target.LogException(ex);
        }
        [Test]
        [Category("version1.0")]
        public void TestLog()
        {
            var target = CreateTargetObject();
            Assert.IsNotNull(target);

            var ex = new Exception("This is a Test for Log");
            target.Log(ex, "True test for Log", ESeverityLevel.Fatal);
        }
        /// <summary>
        /// Tests the name of the interface.
        /// </summary>
        [Test]
        [Category("version1.0")]
        public void TestInterfaceLog()
        {
            var target = CreateTargetInterfaceObject();
            Assert.IsNotNull(target);

            var ex = new Exception("This is a Test for Log interface");
            target.Log(ex, "True test for Log interface", ESeverityLevel.Fatal);
        }


        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.DomainLogger";

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
