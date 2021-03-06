﻿using Core_MovieShelf.Interface.Domain.Contracts;
using NUnit.Framework;

namespace Core_MovieShelf.Test.ContractTests
{
    /// <summary>
    /// TestBookCatalogService.Domain.GenreTypeTest
    /// </summary>
    [TestFixture]
    public class MovieTypeTest : AutoMockerBase<MovieTypeContract>
    {
        #region Target Object Contructors
        /// <summary>
        /// Creates the target object.
        /// </summary>
        /// <returns></returns>
        private static MovieTypeContract CreateTargetObject()
        {
            return new MovieTypeContract();
        }

        /// <summary>
        /// Creates the target interface object.
        /// </summary>
        /// <returns></returns>
        private static IMovieTypeContract CreateTargetInterfaceObject()
        {
            return CreateTargetObject();
        }

        #endregion
    }
}