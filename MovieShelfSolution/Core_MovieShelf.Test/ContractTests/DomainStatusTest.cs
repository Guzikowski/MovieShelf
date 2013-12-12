using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class DomainStatusTest : AutoMockerBase<DomainStatusContract>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static DomainStatusContract CreateTargetObject()
		{
			return new DomainStatusContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IDomainStatusContract CreateTargetInterfaceObject()
		{
			IDomainStatusContract target = CreateTargetObject();
			return target;
		}
		#endregion

		
	}
}
