using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.GenreTypeTest
    /// </summary>
    [TestFixture]
    public class RatingTypeTest : AutoMockerBase<RatingTypeContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static RatingTypeContract CreateTargetObject()
        {
            return new RatingTypeContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IRatingTypeContract CreateTargetInterfaceObject()
        {
            IRatingTypeContract target = CreateTargetObject();
            return target;
        }
        #endregion
    }
}