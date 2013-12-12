using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{

    /// <summary>
    /// TestBookCatalogService.Domain.GenreTypeTest
    /// </summary>
    [TestFixture]
    public class StatusTypeTest : AutoMockerBase<StatusTypeContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static StatusTypeContract CreateTargetObject()
        {
            return new StatusTypeContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IStatusTypeContract CreateTargetInterfaceObject()
        {
            return CreateTargetObject();
        }
        #endregion
    }
}
