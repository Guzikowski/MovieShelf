using System;
using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
	[TestFixture]
	public class BaseDomainTest : AutoMockerBase<BaseDomainContract>
	{
		#region Target Object Contructors
		
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static BaseDomainContract CreateTargetObject()
		{
			return new BaseDomainContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IBaseDomainContract CreateTargetInterfaceObject()
		{
			IBaseDomainContract target = CreateTargetObject();
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

			Assert.IsFalse(target.IsNew);
			target.IsNew = true;
			Assert.IsTrue(target.IsNew);
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

			Assert.IsFalse(target.IsNew);
			((BaseDomainContract)target).IsNew = true;
			Assert.IsTrue(target.IsNew);
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

			CheckProperty(p => p.IsRemoved, false, false, true);
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

			CheckProperty(p => p.IsRemoved, false, false, true);
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
			Assert.IsNull(target.LastModifiedBy);

			CheckProperty(p => p.LastModifiedBy, string.Empty, null, UnitTestValues.LastName1);
		}
		[Test]
		[Category("version1.0")]
		public void TestInterfaceLastModifiedBy()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNull(target.LastModifiedBy);

			target.LastModifiedBy = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.LastModifiedBy);
		}
		[Test]
		[Category("version1.0")]
		public void TestLastmodfiedDate()
		{
			var target = CreateTargetObject();
			Assert.IsNotNull(target.LastModifiedDate);

			CheckProperty(p => p.LastModifiedDate, DateTime.MinValue, DateTime.MinValue, DateTime.MaxValue);
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
			var target = CreateTargetObject();
			Assert.IsNotNull(target.IsValid);

			CheckProperty(p => p.IsValid, false, false, true);
		}
		/// <summary>
		/// Tests the interface is removed.
		/// </summary>
		[Test]
		[Category("version1.0")]
		public void TestInterfaceIsValid()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target.IsValid);

			((BaseDomainContract)target).IsValid = true;
			Assert.IsTrue(target.IsValid);
		}
		
		[Test]
		[Category("version1.0")]
		public void TestStatus()
		{
			var target = CreateTargetInterfaceObject();
			Assert.IsNotNull(target);
			Assert.IsNull(target.DomainStatus);

		}
	}
}
