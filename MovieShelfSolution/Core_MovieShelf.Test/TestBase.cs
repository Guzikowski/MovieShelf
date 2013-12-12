using Core_MovieShelf.Test.DataTests;

namespace Core_MovieShelf.Test
{
    public class TestBase
    {

        #region Additional test attributes
        /// <summary>
        /// Bases the test fixture setup.
        /// </summary>
        protected void BaseTestFixtureSetUp()
        {
        }
        protected void BaseDatabaseTestFixtureSetUp()
        {
            ExecuteCommand("DeleteTestData.sql");
            ExecuteCommand("DeleteReferenceData.sql");
            ExecuteCommand("CreateReferenceData.sql");
        }

        /// <summary>
        /// Bases the test fixture tear down.
        /// </summary>
        protected void BaseTestFixtureTearDown()
        {
        }
        protected void BaseDatabaseTestFixtureTearDown()
        {
            ExecuteCommand("DeleteReferenceData.sql");
        }

        /// <summary>
        /// Bases the test set up.
        /// </summary>
        protected void BaseTestSetUp()
        {
        }
        protected void BaseDatabaseTestSetUp()
        {
            ExecuteCommand("DeleteTestData.sql");
            ExecuteCommand("CreateTestData.sql");
        }

        /// <summary>
        /// Bases the test tear down.
        /// </summary>
        protected void BaseTestTearDown()
        {
        }
        protected void BaseDatabaseTestTearDown()
        {
            ExecuteCommand("DeleteTestData.sql");
        }

        #endregion

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="arg">The arg.</param>
        protected static void ExecuteCommand(string arg)
        {
            var connectionProvider = new DatabaseConnectionProvider();

            using (var command = connectionProvider.GetConnection().CreateCommand())
            {
                command.CommandText = new SqlResourceLoader().LoadSqlStatement(arg);
                command.ExecuteNonQuery();
            }
        }
    }
}
