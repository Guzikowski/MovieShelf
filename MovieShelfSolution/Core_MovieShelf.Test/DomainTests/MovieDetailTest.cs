
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
        public IDomainList<MovieDetail, IEnumerable<MovieDetail>> GetMovieDetailDomainListEntity()
        {
            var result = new DomainList<MovieDetail, IEnumerable<MovieDetail>>
            {
                EntityList = GetMovieDetailListEntity()
            };
            result.Validate();
            return result;
        }
        public IList<MovieDetail> GetMovieDetailListEntity()
        {
            var result = new List<MovieDetail>
            {
                GetMovieDetailEntity() as MovieDetail,
                GetMovieDetailEntity() as MovieDetail,
                GetMovieDetailEntity() as MovieDetail
            };
            return result;
        }

        public IMovieDetail GetMovieDetailEntity()
        {
            var result = new MovieDetail
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

	/// <summary>
	/// TestBookCatalogService.Domain.MovieTest
	/// </summary>
	[TestFixture]
	public class MovieDetailTest : AutoMockerBase<MovieDetail>
	{
		#region Target Object Contructors
		/// <summary>
		/// Creates the target object.
		/// </summary>
		/// <returns></returns>
		private static MovieDetail CreateTargetObject()
		{
			return new MovieDetail();
		}

		/// <summary>
		/// Creates the target interface object.
		/// </summary>
		/// <returns></returns>
		private static IMovieDetail CreateTargetInterfaceObject()
		{
            IMovieDetail target = CreateTargetObject();
			return target;
		}
		#endregion

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

            target.DateCollected = DateTime.MaxValue;
            Assert.IsFalse(target.Validate());
            Assert.IsFalse(target.IsValid);

            target.DateCollected = DateTime.MinValue;
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);

            target.DateCollected = DateTime.Now;
            Assert.IsTrue(target.Validate());
            Assert.IsTrue(target.IsValid);
        }
		
		#region Private Accessor
		/// <summary>
		/// TestBookCatalogService.Domain.BookDetailTest.PrivateAccessor
		/// </summary>
		public class PrivateAccessor
		{
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.MovieDetail";

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