using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.GenreTypeTest
    /// </summary>
    [TestFixture]
    public class ViewRatingTypeTest : AutoMockerBase<ViewRatingTypeContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static ViewRatingTypeContract CreateTargetObject()
        {
            return new ViewRatingTypeContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IViewRatingTypeContract CreateTargetInterfaceObject()
        {
            return CreateTargetObject();
        }
        #endregion
    }
}
