using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Core_MovieShelf.Test.DataTests
{
    [TestFixture]
    public class TestReflectionTestHelper
    {
        [Test]
        public void TestGetInstanceField()
        {
            const string strExpected = "default2";
            var classUnderTest = new ConcreteClass("Private Field Test");
            var objectUnderTest = ReflectionTestHelper.GetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                classUnderTest);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstanceFieldInvalidType()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceField(
                 typeof(BaseClass),
                "_concreteParameter2",
                classUnderTest);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstanceFieldInvalidMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceField(
                 typeof(ConcreteClass),
                "_errorName",
                classUnderTest);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstanceFieldNullMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceField(
                 typeof(ConcreteClass),
                null,
                classUnderTest);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstanceFieldNullObject()
        {
            ReflectionTestHelper.GetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                null);        
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstanceFieldInvalidObject()
        {
            ReflectionTestHelper.GetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                new object());
        }
        [Test]
        public void TestSetInstanceField()
        {
            const string strExpected = "Setting Value Here";
            var classUnderTest = new ConcreteClass("Private Field Test");
            var objectUnderTest = ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                classUnderTest,
                "Setting Value Here");
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldInvalidSetValue()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                classUnderTest,
                1);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldInvalidType()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceField(
                 typeof(BaseClass),
                "_concreteParameter2",
                classUnderTest,
                "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldInvalidMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                "_errorName",
                classUnderTest,
                "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldNullMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                null,
                classUnderTest,
                "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldNullObject()
        {
            ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                null,
                "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstanceFieldInvalidObject()
        {
            ReflectionTestHelper.SetInstanceField(
                 typeof(ConcreteClass),
                "_concreteParameter2",
                new object(),
                "Setting Value Here");
        }
        [Test]
        public void TestGetInstanceProperty()
        {
            const string strExpected = "concrete protected property. default2";
            var classUnderTest = new ConcreteClass("Protected Property Test");
            var objectUnderTest = ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                new object[0]);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);

        }
        [Test]
        [ExpectedException(typeof(System.Reflection.TargetParameterCountException))]
        public void TestGetInstancePropertyParamPresent()
        {
            var classUnderTest = new ConcreteClass("Protected Property Test");
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                new object[] {"test", 2});
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstancePropertyInvalidType()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(BaseClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstancePropertyInvalidMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ErrorName",
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstancePropertyNullMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                null,
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstancePropertyNullObject()
        {
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                null,
                new object[0]);        
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetInstancePropertyInvalidObject()
        {
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                new object(),
                new object[0]);
        }
        [Test]
        public void TestSetInstanceProperty()
        {
            const string strExpected = "concrete protected property. Setting Value Here";
            var classUnderTest = new ConcreteClass("Private Field Test");
            var objectUnderTest = ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                "Setting Value Here",
                new object[0]);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void SetInstancePropertyInvalidSetValue()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                1,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstancePropertyInvalidType()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(BaseClass),
                "ConcreteProtectedProperty",
                classUnderTest,
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstancePropertyInvalidMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                "ErrorName",
                classUnderTest,
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstancePropertyNullMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                null,
                classUnderTest,
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstancePropertyNullObject()
        {
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                null,
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetInstancePropertyInvalidObject()
        {
            ReflectionTestHelper.SetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedProperty",
                new object(),
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        public void TestRunInstanceMethod()
        {
            const string strExpected = "concrete protected method.";
            var classUnderTest = new ConcreteClass("Protected Method Test");
            var objectUnderTest = ReflectionTestHelper.RunInstanceMethod(
                 typeof(ConcreteClass),
                "ConcreteProtectedMethod",
                classUnderTest,
                new object[0]);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(System.Reflection.TargetParameterCountException))]
        public void TestRunInstanceMethodParamPresent()
        {
            var classUnderTest = new ConcreteClass("Protected Property Test");
            ReflectionTestHelper.RunInstanceMethod(
                 typeof(ConcreteClass),
                "ConcreteProtectedMethod",
                classUnderTest,
                new object[] { "test", 2 });
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunInstanceMethodInvalidType()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.RunInstanceMethod(
                 typeof(BaseClass),
                "ConcreteProtectedMethod",
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunInstanceMethodInvalidMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.RunInstanceMethod(
                 typeof(ConcreteClass),
                "ErrorName",
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunInstanceMethodNullMethod()
        {
            var classUnderTest = new ConcreteClass("Private Field Test");
            ReflectionTestHelper.RunInstanceMethod(
                 typeof(ConcreteClass),
                null,
                classUnderTest,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunInstanceMethodNullObject()
        {
            ReflectionTestHelper.RunInstanceMethod(
                 typeof(ConcreteClass),
                "ConcreteProtectedMethod",
                null,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunInstanceMethodInvalidObject()
        {
            ReflectionTestHelper.GetInstanceProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedMethod",
                new object(),
                new object[0]);
        }
        [Test]
        public void TestRunStaticMethod()
        {
            const string strExpected = "concrete private static method.";

            var objectUnderTest = ReflectionTestHelper.RunStaticMethod(
                typeof(ConcreteClass),
                "ConcretePrivateStaticMethod", new object[0]);
            var strActual = Convert.ToString(objectUnderTest);

            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(System.Reflection.TargetParameterCountException))]
        public void TestRunStaticMethodParamPresent()
        {
            ReflectionTestHelper.RunStaticMethod(
                 typeof(ConcreteClass),
                "ConcretePrivateStaticMethod",
                new object[] { "test", 2 });
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunStaticMethodInvalidType()
        {
            ReflectionTestHelper.RunStaticMethod(
                 typeof(BaseClass),
                "ConcretePrivateStaticMethod",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunStaticMethodInvalidMethod()
        {
            ReflectionTestHelper.RunStaticMethod(
                 typeof(ConcreteClass),
                "ErrorName",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRunStaticMethodNullMethod()
        {
            ReflectionTestHelper.RunStaticMethod(
                 typeof(ConcreteClass),
                null,
                new object[0]);
        }
        [Test]
        public void TestGetStaticProperty()
        {
            const string strExpected = "concrete protected static property.";
            var objectUnderTest = ReflectionTestHelper.GetStaticProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedStaticProperty",
                new object[0]);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(System.Reflection.TargetParameterCountException))]
        public void TestGetStaticPropertyParamPresent()
        {
            ReflectionTestHelper.GetStaticProperty(
                 typeof(ConcreteClass),
                "ConcreteProtectedStaticProperty",
                new object[] { "test", 2 });
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticPropertyInvalidType()
        {
            ReflectionTestHelper.GetStaticProperty(
                 typeof(BaseClass),
                "ConcreteProtectedStaticProperty",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticPropertyInvalidMethod()
        {
            ReflectionTestHelper.GetStaticProperty(
                 typeof(ConcreteClass),
                "ErrorName",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticPropertyNullMethod()
        {
            ReflectionTestHelper.GetStaticProperty(
                 typeof(ConcreteClass),
                null,
                new object[0]);
        }
        [Test]
        public void TestGetStaticField()
        {
            const string strExpected = "default";
            var objectUnderTest = ReflectionTestHelper.GetStaticField(
                 typeof(ConcreteClass),
                "_staticParameter");
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticFieldInvalidType()
        {
            ReflectionTestHelper.GetStaticField(
                 typeof(BaseClass),
                "_staticParameter");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticFieldInvalidMethod()
        {
            ReflectionTestHelper.GetStaticField(
                 typeof(ConcreteClass),
                "ErrorName");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetStaticFieldNullMethod()
        {
            ReflectionTestHelper.GetStaticField(
                 typeof(ConcreteClass),
                null);
        }
        [Test]
        public void TestSetStaticProperty()
        {
            const string strExpected = "concrete private property. Setting Value Here";
            var objectUnderTest = ReflectionTestHelper.SetStaticProperty(
                 typeof(ConcreteClass),
                "ConcretePrivateStaticProperty",
                "Setting Value Here",
                new object[0]);
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticPropertyInvalidSetValue()
        {
            ReflectionTestHelper.SetStaticProperty(
                 typeof(ConcreteClass),
                "ConcretePrivateStaticProperty",
                1,
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticPropertyInvalidType()
        {
            ReflectionTestHelper.SetStaticProperty(
                 typeof(BaseClass),
                "ConcretePrivateStaticProperty",
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticPropertyInvalidMethod()
        {
            ReflectionTestHelper.SetStaticProperty(
                 typeof(ConcreteClass),
                "ErrorName",
                "Setting Value Here",
                new object[0]);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticPropertyNullMethod()
        {
            ReflectionTestHelper.SetStaticProperty(
                 typeof(ConcreteClass),
                null,
                "Setting Value Here",
                new object[0]);
        }       
        [Test]
        public void TestSetStaticField()
        {
            const string strExpected = "Setting Value Here";
            var objectUnderTest = ReflectionTestHelper.SetStaticField(
                 typeof(ConcreteClass),
                "_staticParameter",
                "Setting Value Here");
            var strActual = Convert.ToString(objectUnderTest);
            Assert.AreEqual(strExpected, strActual);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticFieldInvalidSetValue()
        {
            ReflectionTestHelper.SetStaticField(
                 typeof(ConcreteClass),
                "_staticParameter",
                1);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticFieldInvalidType()
        {
            ReflectionTestHelper.SetStaticField(
                 typeof(BaseClass),
                "_staticParameter",
                "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticFieldInvalidMethod()
        {
            ReflectionTestHelper.SetStaticField(
                 typeof(ConcreteClass),
                "_errorName",
               "Setting Value Here");
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSetStaticFieldNullMethod()
        {
            ReflectionTestHelper.SetStaticField(
                 typeof(ConcreteClass),
                null,
                "Setting Value Here");
        }
        

    }
    public interface IBaseClass
    {
        string BasePublicProperty { get; }

        string BasePublicMethod();

    }
    public interface IConcreteClass : IBaseClass
    {
        string ConcretePublicProperty { get; }

        string ConcretePublicMethod();

    }
    public abstract class BaseClass : IBaseClass
    {
        private string _baseParameter = "default";
        protected IList<string> BaseSampleList;

        protected BaseClass(string parameter)
        {
            BasePrivateProperty = parameter;

            BaseSampleList = new List<string>
                             {
                                 BasePrivateProperty,
                                 BasePrivateStaticProperty,
                                 BasePrivateMethod(),
                                 BasePrivateStaticMethod(),
                                 BasePrivateMethodWithParameters("test value", 99),
                                 BasePrivateStaticMethodWithParameters("testing value", 77)
                             };
        }

        public string BasePublicProperty
        {
            get { return "base public property."; }
        }
        public static string BasePublicStaticProperty
        {
            get { return "base public static property."; }
        }

        protected virtual string BaseProtectedProperty
        {
            get { return "base protected property."; }
        }
        protected static string BaseProtectedStaticProperty
        {
            get { return "base protected static property."; }
        }
        private string BasePrivateProperty
        {
            get { return string.Format("base private property. {0}", _baseParameter); }
            set { _baseParameter = value; }
        }
        private static string BasePrivateStaticProperty
        {
            get { return "base private static property."; }
        }

        public virtual string BasePublicMethod()
        {
            return "base public method.";
        }
        public static string BasePublicStaticMethod()
        {
            return "base public static method.";
        }

        protected virtual string BaseProtectedMethod()
        {
            return "base protected method.";
        }
        protected static string BaseProtectedStaticMethod()
        {
            return "base protected static method.";
        }
        private string BasePrivateMethod()
        {
            return string.Format("base private method. {0}", _baseParameter);
        }
        private static string BasePrivateStaticMethod()
        {
            return "base private static method.";
        }
        private string BasePrivateMethodWithParameters(string value, int index)
        {
            return string.Format("base private method with parameters: arg1 = '{0}' arg2 = '{1}'. {2}", value, index, _baseParameter);
        }
        private static string BasePrivateStaticMethodWithParameters(string value, int index)
        {
            return string.Format("base private static method with parameters: arg1 = '{0}' arg2 = '{1}'. ", value, index);
        }
    }
    public class ConcreteClass : BaseClass, IConcreteClass
    {
        protected IList<string> ConcreteSampleList;
        private static string _staticParameter = "not initialised";

        public ConcreteClass(string parameter)
            : base(parameter)
        {
            if (string.IsNullOrEmpty(_staticParameter)
            || (_staticParameter == "not initialised"))
            {
                _staticParameter = "default";
            }
            ConcretePrivateProperty = parameter;
            ConcretePrivateStaticProperty = _staticParameter;

            ConcreteSampleList = new List<string>
                             {
                                 ConcretePrivateProperty,
                                 ConcretePrivateStaticProperty,
                                 ConcretePrivateMethod(),
                                 ConcretePrivateStaticMethod()
                             };
        }
        public string ConcretePublicProperty
        {
            get { return "concrete public property."; }
        }
        public static string ConcretePublicStaticProperty
        {
            get { return "concrete public static property."; }
        }
        protected override string BaseProtectedProperty
        {
            get { return "overridde base protected property."; }
        }
        protected string ConcreteProtectedProperty
        {
            get { return string.Format("concrete protected property. {0}", _concreteParameter2); }
            set { _concreteParameter2 = value; }
        } private string _concreteParameter2 = "default2";
        protected static string ConcreteProtectedStaticProperty
        {
            get { return "concrete protected static property."; }
        }
        private string ConcretePrivateProperty
        {
            get { return string.Format("concrete private property. {0}", _concreteParameter); }
            set { _concreteParameter = value; }
        } private string _concreteParameter = "default";

        private static string ConcretePrivateStaticProperty
        {
            get { return string.Format("concrete private property. {0}", _concreteStaticParameter); }
            set { _concreteStaticParameter = value; }
        } private static string _concreteStaticParameter = "default";

        public override string BasePublicMethod()
        {
            return "overridden base public method.";
        }
        public string ConcretePublicMethod()
        {
            return "concrete public method.";
        }
        public static string ConcretePublicStaticMethod()
        {
            return "concrete public static method.";
        }
        protected override string BaseProtectedMethod()
        {
            return "overriden base protected method.";
        }
        protected string ConcreteProtectedMethod()
        {
            return "concrete protected method.";
        }
        protected static string ConcreteProtectedStaticMethod()
        {
            return "concrete protected static method.";
        }
        private string ConcretePrivateMethod()
        {
            return string.Format("concrete private method. {0}", _concreteParameter);
        }
        private static string ConcretePrivateStaticMethod()
        {
            return "concrete private static method.";
        }
    }
}
