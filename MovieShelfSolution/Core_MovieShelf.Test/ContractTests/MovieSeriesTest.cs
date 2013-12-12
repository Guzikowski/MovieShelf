using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class MovieSeriesTest : AutoMockerBase<MovieSeriesContract>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static MovieSeriesContract CreateTargetObject()
		{
			return new MovieSeriesContract();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IMovieSeriesContract CreateTargetInterfaceObject()
		{
			IMovieSeriesContract target = CreateTargetObject();
			return target;
		}
		#endregion
	}
}