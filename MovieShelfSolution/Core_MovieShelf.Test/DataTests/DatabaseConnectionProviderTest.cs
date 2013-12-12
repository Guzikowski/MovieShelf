using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

namespace Core_MovieShelf.Test.DataTests
{
	#region MockHelper

	#endregion

	/// <summary>
	/// TestBookCatalogService.Data.DatabaseConnectionProviderTest
	/// </summary>
	[TestFixture]
	public class DatabaseConnectionProviderTest : AutoMockerBase<DatabaseConnectionProvider>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static DatabaseConnectionProvider CreateTargetObject()
		{
			return new DatabaseConnectionProvider();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IDatabaseConnectionProvider CreateTargetInterfaceObject()
		{
			IDatabaseConnectionProvider target = CreateTargetObject();
			return target;
		}
		#endregion

		/// <summary>
		/// Tests the get connection.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestGetConnection()
		{
			var target = CreateTargetObject();
			var actual = target.GetConnection();
			Assert.IsNotNull(actual);
		}
		/// <summary>
		/// Tests the interface get connection.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceGetConnection()
		{
			var target = CreateTargetInterfaceObject();
			var actual = target.GetConnection();
			Assert.IsNotNull(actual);
		}
		/// <summary>
		/// Tests the name of the server.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestServerName()
		{
			var param0 = PrivateAccessor.CreatePrivate();
			var target = new PrivateAccessor(param0);
			Assert.IsNotNull(target.ServerName);
		}
		/// <summary>
		/// Tests the name of the database.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestDatabaseName()
		{
			var param0 = PrivateAccessor.CreatePrivate();
			var target = new PrivateAccessor(param0);
			Assert.IsNotNull(target.DatabaseName);
		}
		/// <summary>
		/// Tests the usercode.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestUsercode()
		{
			var param0 = PrivateAccessor.CreatePrivate();
			var target = new PrivateAccessor(param0);
			Assert.IsNotNull(target.Usercode);
		}
		/// <summary>
		/// Tests the password.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestPassword()
		{
			var param0 = PrivateAccessor.CreatePrivate();
			var target = new PrivateAccessor(param0);
			Assert.IsNotNull(target.Password);
		}

		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.AuthorDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
            private const string FileName = "Core_MovieShelf.Test";
            private const string FullClassName = "Core_MovieShelf.Test.DataTests.DatabaseConnectionProvider";

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

			/// <summary>
			/// Gets or sets the name of the server.
			/// </summary>
			/// <value>The name of the server.</value>
			public string ServerName
			{
				get
				{
					return (string)MmsPrivateType.GetStaticFieldOrProperty("ServerName");
				}
				set
				{
					MmsPrivateType.SetStaticFieldOrProperty("ServerName", value);
				}
			}
			/// <summary>
			/// Gets or sets the name of the database.
			/// </summary>
			/// <value>The name of the database.</value>
			public string DatabaseName
			{
				get
				{
					return (string)MmsPrivateType.GetStaticFieldOrProperty("DatabaseName");
				}
				set
				{
					MmsPrivateType.SetStaticFieldOrProperty("DatabaseName", value);
				}
			}

			/// <summary>
			/// Gets or sets the usercode.
			/// </summary>
			/// <value>The usercode.</value>
			public string Usercode
			{
				get
				{
					return (string)MmsPrivateType.GetStaticFieldOrProperty("Usercode");
				}
				set
				{
					MmsPrivateType.SetStaticFieldOrProperty("Usercode", value);
				}
			}

			/// <summary>
			/// Gets or sets the password.
			/// </summary>
			/// <value>The password.</value>
			public string Password
			{
				get
				{
					return (string)MmsPrivateType.GetStaticFieldOrProperty("Password");
				}
				set
				{
					MmsPrivateType.SetStaticFieldOrProperty("Password", value);
				}
			}
		}
		#endregion
	}
}