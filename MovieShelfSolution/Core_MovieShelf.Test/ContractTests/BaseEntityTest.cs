using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
	/// <summary>
	/// TestBookCatalogService.Domain.BaseLookupTest
	/// </summary>
	[TestFixture]
	public class BaseEntityTest : AutoMockerBase<BaseEntityContract>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static BaseEntityContract CreateTargetObject()
		{
			return new BaseEntityContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IBaseEntityContract CreateTargetInterfaceObject()
		{
			IBaseEntityContract target = CreateTargetObject();
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
			Assert.IsNull(target.Name);
			
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
			Assert.IsNull(target.Name);
			
			target.Name = UnitTestValues.LastName1;
			Assert.AreEqual(UnitTestValues.LastName1, target.Name);
		}
	}
}