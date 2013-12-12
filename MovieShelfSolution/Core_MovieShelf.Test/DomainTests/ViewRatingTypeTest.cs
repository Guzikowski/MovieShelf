using System;
using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain;
using NUnit.Framework;
using MSPrivateObject = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject;
using MSPrivateType = Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType;
using RatingType = Core_MovieShelf.Data.RatingType;
using ViewRatingType = Core_MovieShelf.Data.ViewRatingType;


namespace Core_MovieShelf.Test.MockObjects
{
    /// <summary>
    /// TestBookCatalogService.Domain.MockHelper
    /// </summary>
    public partial class MockHelper
    {
        public IDomainList<Domain.ViewRatingType, IEnumerable<Domain.ViewRatingType>> GetViewRatingTypeDomainListEntity()
        {
            var result = new DomainList<Domain.ViewRatingType, IEnumerable<Domain.ViewRatingType>>
            {
                EntityList = GetViewRatingTypeListEntity()
            };
            result.Validate();
            return result;
        }
        public IList<Domain.ViewRatingType> GetViewRatingTypeListEntity()
        {
            var result = new List<Domain.ViewRatingType>
            {
                GetViewRatingTypeEntity() as Domain.ViewRatingType,
                GetViewRatingTypeEntity() as Domain.ViewRatingType,
                GetViewRatingTypeEntity() as Domain.ViewRatingType
            };
            return result;
        }

        public IViewRatingType GetViewRatingTypeEntity()
        {
            var result = new Domain.ViewRatingType
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
    /// TestBookCatalogService.Domain.GenreTypeTest
    /// </summary>
    [TestFixture]
    public class ViewRatingTypeTest : AutoMockerBase<ViewRatingType>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static ViewRatingType CreateTargetObject()
        {
            return new ViewRatingType();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IViewRatingType CreateTargetInterfaceObject()
        {
            return CreateTargetObject() as IViewRatingType;
        }
        #endregion


        #region Private Accessor
        /// <summary>
        /// TestBookCatalogService.Domain.AuthorDetailTest.PrivateAccessor
        /// </summary>
        public class PrivateAccessor
        {
            private const string FileName = "Core_MovieShelf";
            private const string FullClassName = "Core_MovieShelf.Domain.ViewRatingType";

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
