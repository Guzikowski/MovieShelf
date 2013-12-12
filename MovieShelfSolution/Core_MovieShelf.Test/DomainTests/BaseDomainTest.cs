using System;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

namespace Core_MovieShelf.Test.DomainTests
{
	[TestFixture]
	public class BaseDomainTest : AutoMockerBase<BaseDomain>
	{
		#region Target Object Contructors
		/// <summary>
		/// TestBookCatalogService.Domain.BaseDomainTest.ConcreteBaseDomain
		/// </summary>
		public class ConcreteBaseDomain : BaseDomain
		{
			public ConcreteBaseDomain()
			{
			}
			public ConcreteBaseDomain(IBaseDomainContract baseDomain) : base(baseDomain)
			{
			}
		}
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static ConcreteBaseDomain CreateTargetObject()
		{
			return new ConcreteBaseDomain();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IBaseDomain CreateTargetInterfaceObject()
		{
			IBaseDomain target = CreateTargetObject();
			return target;
		}
		#endregion

		/// <summary>
		/// Tests the is new.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestIsNew()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.IsNew);

			target.Id = 0;
			Assert.IsTrue(target.IsNew);
			target.Id = 1;
			Assert.IsFalse(target.IsNew);
		}
		/// <summary>
		/// Tests the interface is new.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceIsNew()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.IsNew);

			target.Id = 0;
			Assert.IsTrue(target.IsNew);
			target.Id = 1;
			Assert.IsFalse(target.IsNew);
		}
		/// <summary>
		/// Tests the is removed.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestIsRemoved()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.IsRemoved);

			Assert.IsFalse(target.IsRemoved);

			target.Id = 0;
			target.IsRemoved = true;
			Assert.IsFalse(target.IsRemoved);

			target.Id = 1;
			target.IsRemoved = true;
			Assert.IsTrue(target.IsRemoved);

		}
		/// <summary>
		/// Tests the interface is removed.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceIsRemoved()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.IsRemoved);
			target.Id = 1;
			target.IsRemoved = true;
			Assert.IsTrue(target.IsRemoved);
		}
		/// <summary>
		/// Tests the has changed.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestHasChanged()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.HasChanged);

			Assert.IsFalse(target.HasChanged);

			target.Id = 0;
			target.HasChanged = true;
			Assert.IsFalse(target.HasChanged);

			target.Id = 1;
			target.HasChanged = true;
			Assert.IsTrue(target.HasChanged);
		}
		/// <summary>
		/// Tests the interface has changed.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceHasChanged()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.HasChanged);

			Assert.IsFalse(target.HasChanged);

			target.Id = 0;
			target.HasChanged = true;
			Assert.IsFalse(target.HasChanged);

			target.Id = 1;
			target.HasChanged = true;
			Assert.IsTrue(target.HasChanged);
		}
		/// <summary>
		/// Tests the id.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestId()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.Id);

			CheckProperty(p => p.Id, 0, 0, int.MaxValue);
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

			target.Id = UnitTestValues.Id;
			Assert.AreEqual(UnitTestValues.Id, target.Id);
		}


		[Test]
		[Category("version1.0")]
		public void TestLastModfiedBy()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.LastModifiedBy);

			CheckProperty(p => p.LastModifiedBy, string.Empty, string.Empty, UnitTestValues.LastName1);
		}
		[Test]
		[Category("version1.0")]
		public void TestInterfaceLastModifiedBy()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.LastModifiedBy);

			target.LastModifiedBy = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.LastModifiedBy);
		}
		[Test]
		[Category("version1.0")]
		public void TestLastmodfiedDate()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.LastModifiedDate);

			CheckProperty(p => p.LastModifiedDate, DateTime.MinValue, DateTime.Now.Date, DateTime.Now);
		}

		[Test]
		[Category("version1.0")]
		public void TestInterfaceLastModifiedDate()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.LastModifiedDate);

			target.LastModifiedDate = DateTime.Now.Date;
			Assert.AreEqual(DateTime.Now.Date, target.LastModifiedDate);
		}
		/// <summary>
		/// Tests the timestamp.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestTimestamp()
		{
			var target = CreateTargetObject();
			Assert.IsNull(target.Timestamp);

			CheckProperty(p => p.Timestamp, UnitTestValues.TimestampBegin, null, UnitTestValues.TimestampEnd);
		}
		/// <summary>
		/// Tests the interface timestamp.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceTimestamp()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNull(target.Timestamp);

			target.Timestamp = UnitTestValues.TimestampBegin;
			Assert.AreEqual(UnitTestValues.TimestampBegin, target.Timestamp);
		}
		[Test]
		[Category("version1.0")]
		public void TestIsValid()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target);

			Assert.IsTrue(target.Validate());
			Assert.IsTrue(target.IsValid);

			target.Id = 1;
			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);

			target.LastModifiedBy = "testUser";
			Assert.IsTrue(target.Validate());
			Assert.IsTrue(target.IsValid);

			target.LastModifiedBy = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);

			target.LastModifiedBy = "testUser";
			target.LastModifiedDate = DateTime.MinValue;
			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);
			
			target.LastModifiedDate = DateTime.Now;
			Assert.IsTrue(target.Validate());
			Assert.IsTrue(target.IsValid);
		}
		[Test]
		[Category("version1.0")]
		public void TestReset()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target);

			target.Id = 1;
			target.HasChanged = true;
			Assert.IsFalse(target.Validate());

			target.Reset();

			Assert.IsFalse(target.HasChanged);
			Assert.IsTrue(target.DomainStatus.Messages.Count == 0);

		}
		[Test]
		[Category("version1.0")]
		public void TestStatus()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target);
			Assert.IsNotNull(target.DomainStatus);

		}
		[Test]
		[Category("version1.0")]
		public void TestConvertToContract()
		{
			var testObject = CreateTargetInterfaceObject();
			Assert.IsNotNull(testObject);
			testObject.Id = 1;
			testObject.LastModifiedBy = "Joe";
			testObject.LastModifiedDate = DateTime.Now;
			testObject.Timestamp = UnitTestValues.TimestampBegin;
			testObject.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong));


            var actualResult = CreateTargetObject().ConvertToContract((BaseDomain)testObject, new BaseDomainContract());
			Assert.IsNotNull(actualResult);
			Assert.IsTrue(actualResult.HasChanged == testObject.HasChanged);
			Assert.IsTrue(actualResult.Id == testObject.Id);
			Assert.IsTrue(actualResult.IsNew == testObject.IsNew);
			Assert.IsTrue(actualResult.IsRemoved == testObject.IsRemoved);
			Assert.IsTrue(actualResult.IsValid == testObject.IsValid);
			Assert.IsTrue(actualResult.LastModifiedBy == testObject.LastModifiedBy);
			Assert.IsTrue(actualResult.LastModifiedDate == testObject.LastModifiedDate);
			Assert.IsTrue(actualResult.Timestamp == testObject.Timestamp);
			Assert.IsTrue(actualResult.DomainStatus.Messages.Count == testObject.DomainStatus.Messages.Count);
		}

		[Test]
		[Category("version1.0")]
		public void TestConvertToDomain()
		{
			var testObject = new BaseDomainContract();
			Assert.IsNotNull(testObject);
			testObject.HasChanged = true;
			testObject.Id = 1;
			testObject.IsNew = false;
			testObject.IsRemoved = false;
			testObject.IsValid = true;
			testObject.LastModifiedBy = "Joe";
			testObject.LastModifiedDate = DateTime.Now;
			testObject.Timestamp = UnitTestValues.TimestampBegin;
		   // testObject.DomainStatus.AddMessage(MessageHelper.Get(EMessageNumber.ErrorLastModifiedByToLong));


			var actualResult = new ConcreteBaseDomain(testObject);
			Assert.IsNotNull(actualResult);
			Assert.IsTrue(actualResult.HasChanged == testObject.HasChanged);
			Assert.IsTrue(actualResult.Id == testObject.Id);
			Assert.IsTrue(actualResult.IsNew == testObject.IsNew);
			Assert.IsTrue(actualResult.IsRemoved == testObject.IsRemoved);
			Assert.IsTrue(actualResult.IsValid == testObject.IsValid);
			Assert.IsTrue(actualResult.LastModifiedBy == testObject.LastModifiedBy);
			Assert.IsTrue(actualResult.LastModifiedDate == testObject.LastModifiedDate);
			Assert.IsTrue(actualResult.Timestamp == testObject.Timestamp);
		   // Assert.IsTrue(actualResult.DomainStatus.Messages.Count == testObject.DomainStatus.Messages.Count);
		}
		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.AuthorDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
			private const string FileName = "BookCatalogService";
			private const string FullClassName = "BookCatalogService.Domain.BaseDomain";

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
