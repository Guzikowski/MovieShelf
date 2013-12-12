using System;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;

namespace Core_MovieShelf.Test.DomainTests
{
	/// <summary>
	/// TestBookCatalogService.Domain.BaseLookupTest
	/// </summary>
	[TestFixture]
	public class BaseEntityTest : AutoMockerBase<BaseEntity>
	{
		#region Target Object Contructors
		
		/// <summary>
		/// TestBookCatalogService.Domain.BaseLookupTest.ConcreteBaseLookup
		/// </summary>
		public class ConcreteBaseEntity : BaseEntity
		{
			public ConcreteBaseEntity()
			{
			}
			public ConcreteBaseEntity(IBaseEntityContract baseDomain)
				: base(baseDomain)
			{
			}
		}
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static ConcreteBaseEntity CreateTargetObject()
		{
			return new ConcreteBaseEntity();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IBaseEntity CreateTargetInterfaceObject()
		{
			IBaseEntity target = CreateTargetObject();
			return target;
		}
		#endregion

		/// <summary>
		/// Tests the name.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestName()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.Name);
			Assert.IsTrue(target.Name == string.Empty);

			CheckProperty(p => p.Name, null, string.Empty, UnitTestValues.LastName1);
		}
		/// <summary>
		/// Tests the name of the interface.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceName()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.Name);
			Assert.IsTrue(target.Name == string.Empty);

			target.Name = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.Name);
		}
		[Test]
		[Category("version1.0")]
		public void TestIsValid()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target);

			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);

			target.Name = "testName";
			Assert.IsTrue(target.Validate());
			Assert.IsTrue(target.IsValid);

			target.Id = 1;
			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);

			target.LastModifiedBy = "testUser";
			Assert.IsTrue(target.Validate());
			Assert.IsTrue(target.IsValid);

			target.Name = "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890";
			Assert.IsFalse(target.Validate());
			Assert.IsFalse(target.IsValid);
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
			testObject.Name = "Da Movie";
			testObject.DisplayImage = new DisplayImage { Name = "Imagery" };

			var actualResult = CreateTargetObject().ConvertToContract((BaseEntity)testObject, new BaseEntityContract());
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
			Assert.IsTrue(actualResult.Name == testObject.Name);
			Assert.IsTrue(actualResult.DisplayImage.Name == testObject.DisplayImage.Name);
		}

		[Test]
		[Category("version1.0")]
		public void TestConvertToDomain()
		{
			var testObject = new BaseEntityContract();
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
			testObject.Name = "Da Movie";
			testObject.DisplayImage = new DisplayImageContract { Name = "Imagery" };

			var actualResult = new ConcreteBaseEntity(testObject);
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
			Assert.IsTrue(actualResult.Name == testObject.Name);
			Assert.IsTrue(actualResult.DisplayImage.Name == testObject.DisplayImage.Name);

		}




		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.AuthorDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
			private const string FileName = "Core_MovieShelf";
			private const string FullClassName = "Core_MovieShelf.Domain.BaseEntity";

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