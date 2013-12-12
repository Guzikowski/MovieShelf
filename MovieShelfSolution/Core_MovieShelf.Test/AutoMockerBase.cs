using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;
using StructureMap.AutoMocking;

namespace Core_MovieShelf.Test
{

    public abstract partial class AutoMockerBase<TClassUnderTest> : TestBase where TClassUnderTest : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMockerBase&lt;TClassUnderTest&gt;"/> class.
        /// </summary>
        protected AutoMockerBase()
        {
            ReBuildMockInstances();
        }

        protected RhinoAutoMocker<TClassUnderTest> AutoMocker { get; private set; }

        protected TClassUnderTest ClassUnderTest { get; set; }

        /// <summary>
        /// Res the build mock instances.
        /// </summary>
        protected void ReBuildMockInstances()
        {
            AutoMocker = new RhinoAutoMocker<TClassUnderTest>(MockMode.AAA);
            ClassUnderTest = AutoMocker.ClassUnderTest;

        }

        /// <summary>
        /// Checks the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="min">The min.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="max">The max.</param>
        public void CheckProperty<T>(Expression<Func<TClassUnderTest, T>> expression, T min, T defaultValue, T max)
        {
            var info = ExtractPropertyInfo(expression);
            // Check Default
            CompareValue(info, defaultValue, "Default Value");
            // Check min value
            CompareSetValue(info, min, "Set Minimum Value");
            // Check max value
            CompareSetValue(info, max, "Set Maximum Value");
            // Check setting default value
            CompareSetValue(info, defaultValue, "Set Default Value");
        }

        /// <summary>
        /// Compares the set value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info">The info.</param>
        /// <param name="checkValue">The check value.</param>
        /// <param name="testName"></param>
        private void CompareSetValue<T>(PropertyInfo info, T checkValue, string testName)
        {
            info.SetValue(ClassUnderTest, checkValue, null);
            CompareValue(info, checkValue, testName);
        }

        /// <summary>
        /// Compares the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info">The info.</param>
        /// <param name="checkValue">The check value.</param>
        /// <param name="testName"></param>
        private void CompareValue<T>(PropertyInfo info, T checkValue, string testName)
        {
            Assert.IsTrue(
                typeof (T) == typeof (DateTime)
                    ? Equals(GetValue<T>(info).ToString(), checkValue.ToString())
                    : EqualityComparer<T>.Default.Equals(GetValue<T>(info), checkValue),
                string.Format("check value failed : {0} for test {1} actual value was : {2}", checkValue, testName,
                              GetValue<T>(info)));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="info">The info.</param>
        /// <returns></returns>
        private T GetValue<T>(PropertyInfo info)
        {
            return (T)info.GetValue(ClassUnderTest, null);
        }

        /// <summary>
        /// Extracts the property info.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        private static PropertyInfo ExtractPropertyInfo(LambdaExpression expression)
        {
            var prop = expression.Body as MemberExpression;

            if (prop != null)
            {
                var info = prop.Member as PropertyInfo;
                if (info != null)
                {
                    return info;
                }
            }

            throw new ArgumentException("Expression is not a property");
        }
    }
}