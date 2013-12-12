using System;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

namespace Core_MovieShelf.Test.DataTests
{
	#region MockHelper

	#endregion

	/// <summary>
	/// TestBookCatalogService.Data.SqlResourceLoaderTest
	/// </summary>
	[TestFixture]
	public class SqlResourceLoaderTest : AutoMockerBase<SqlResourceLoader>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static SqlResourceLoader CreateTargetObject()
		{
			return new SqlResourceLoader();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static ISqlResourceLoader CreateTargetInterfaceObject()
		{
			ISqlResourceLoader target = CreateTargetObject();
			return target;
		}
		#endregion


		/// <summary>
		/// Tests the load SQL statement.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestLoadSqlStatement()
		{
			var target = CreateTargetObject();
			var actual = target.LoadSqlStatement("CreateTestData.sql");
			Assert.IsNotNull(actual);
		}
		/// <summary>
		/// Tests the load SQL statement invalid file.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestLoadSqlStatementInvalidFile()
		{
			var target = CreateTargetObject();
			var actual = target.LoadSqlStatement("NoFile.sql");
			Assert.IsNotNull(actual);
		}
		/// <summary>
		/// Tests the load SQL statement null file.
		/// </summary>
		[Test]
		[Category("version1.0")]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestLoadSqlStatementNullFile()
		{
			var target = CreateTargetObject();
			var actual = target.LoadSqlStatement(null);
			Assert.IsNotNull(actual);
		}
		/// <summary>
		/// Tests the interface load SQL statement.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceLoadSqlStatement()
		{
			var target = CreateTargetInterfaceObject();
			var actual = target.LoadSqlStatement("CreateTestData.sql");
			Assert.IsNotNull(actual);
		}

		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.AuthorDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
			private const string FileName = "BookCatalogService";
			private const string FullClassName = "BookCatalogService.Data.SqlResourceLoader";

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