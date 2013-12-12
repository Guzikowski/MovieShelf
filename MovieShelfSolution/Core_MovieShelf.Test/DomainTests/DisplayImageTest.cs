
using System;
using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;
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
		public IDomainList<DisplayImage, IEnumerable<DisplayImage>> GetDisplayImageDomainListEntity()
		{
			var result = new DomainList<DisplayImage, IEnumerable<DisplayImage>>
			{
				EntityList = GetDisplayImageListEntity()
			};
			result.Validate();
			return result;
		}

		public IList<DisplayImage> GetDisplayImageListEntity()
		{
			var result = new List<DisplayImage>
			{
				GetDisplayImageEntity() as DisplayImage,
				GetDisplayImageEntity() as DisplayImage,
				GetDisplayImageEntity() as DisplayImage
			};
			return result;
		}
		public IDisplayImage GetDisplayImageEntity()
		{
			var result = new DisplayImage
							 {
								 Id = 1,
								 LastModifiedBy = "joe",
								 LastModifiedDate = DateTime.Now,
							 };

			return result;
		}
	}
}

namespace Core_MovieShelf.Test.DomainTests
{
	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class DisplayImageTest : AutoMockerBase<DisplayImage>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static DisplayImage CreateTargetObject()
		{
			return new DisplayImage();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IDisplayImage CreateTargetInterfaceObject()
		{
			IDisplayImage target = CreateTargetObject();
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

			CheckProperty(p => p.Name, null, null, UnitTestValues.LastName1);
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

			target.Name = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.Name);
		}
		/// <summary>
		/// Tests the name.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestPath()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.Path);

			CheckProperty(p => p.Path, null, null, UnitTestValues.LastName1);
		}
		/// <summary>
		/// Tests the name of the interface.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfacePath()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.Path);

			target.Path = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.Path);
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
			testObject.Path = "Somewhere";

			var actualResult = CreateTargetObject().ConvertToContract((DisplayImage)testObject, new DisplayImageContract());
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
			Assert.IsTrue(actualResult.Path == testObject.Path);
		}

		[Test]
		[Category("version1.0")]
		public void TestConvertToDomain()
		{
			var testObject = new DisplayImageContract();
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
			testObject.Path = "Somewhere";

			var actualResult = new DisplayImage(testObject);
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
			Assert.IsTrue(actualResult.Path == testObject.Path);

		}
		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
			private const string FileName = "Core_MovieShelf";
			private const string FullClassName = "Core_MovieShelf.Domain.DisplayImage";

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
