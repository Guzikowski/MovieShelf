
using System;
using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
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
        public IDomainList<MovieSeries, IEnumerable<MovieSeries>> GetMovieSeriesDomainListEntity()
        {
            var result = new DomainList<MovieSeries, IEnumerable<MovieSeries>>
            {
                EntityList = GetMovieSeriesListEntity()
            };
            result.Validate();
            return result;
        }
        public IList<MovieSeries> GetMovieSeriesListEntity()
        {
            var result = new List<MovieSeries>
            {
                GetMovieSeriesEntity() as MovieSeries,
                GetMovieSeriesEntity() as MovieSeries,
                GetMovieSeriesEntity() as MovieSeries
            };
            return result;
        }

        public IMovieSeries GetMovieSeriesEntity()
        {
            var result = new MovieSeries
            {
                LastModifiedBy = "joe",
                LastModifiedDate = DateTime.Now,
                Name = "TestName",
                DisplayImage = GetDisplayImageEntity()
            };
            return result;
        }
    }
}
namespace Core_MovieShelf.Test.DomainTests
{
	#region MockHelper

	#endregion

	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class MovieSeriesTest : AutoMockerBase<MovieSeries>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static MovieSeries CreateTargetObject()
		{
			return new MovieSeries();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IMovieSeries CreateTargetInterfaceObject()
		{
            IMovieSeries target = CreateTargetObject();
			return target;
		}
		#endregion

		
		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.MovieSeries";

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