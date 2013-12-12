using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{

	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class MovieDetailTest : AutoMockerBase<MovieDetailContract>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static MovieDetailContract CreateTargetObject()
		{
			return new MovieDetailContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IMovieDetailContract CreateTargetInterfaceObject()
		{
			IMovieDetailContract target = CreateTargetObject();
			return target;
		}
		#endregion
	}
}