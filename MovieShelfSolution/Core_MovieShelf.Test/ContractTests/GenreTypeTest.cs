using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{

	/// <summary>
	/// TestBookCatalogService.Domain.GenreTypeTest
	/// </summary>
	[TestFixture]
	public class GenreTypeTest : AutoMockerBase<GenreTypeContract>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static GenreTypeContract CreateTargetObject()
		{
			return new GenreTypeContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IGenreTypeContract CreateTargetInterfaceObject()
		{
			IGenreTypeContract target = CreateTargetObject();
			return target;
		}
		#endregion

	}
}