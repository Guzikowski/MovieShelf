using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Core_MovieShelf.Test.DataTests
{
    /// <summary>
    /// IBookCatalogService.Data.IDatabaseConnectionProvider
    /// </summary>
    public interface IDatabaseConnectionProvider
    {
        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        SqlConnection GetConnection();
    }
    /// <summary>
    /// BookCatalogService.Data.DatabaseConnectionProvider
    /// </summary>
    public class DatabaseConnectionProvider : IDatabaseConnectionProvider
    {
        private const string DbConnection = "Data Source={0};Initial Catalog={1};User Id={2};Password={3}";

        private static readonly string ServerName = ConfigurationManager.AppSettings["DatabaseServerName"];
        private static readonly string DatabaseName = ConfigurationManager.AppSettings["DatabaseName"];
        private static readonly string Usercode = ConfigurationManager.AppSettings["UnitTesterUserName"];
        private static readonly string Password = ConfigurationManager.AppSettings["UnitTesterPassword"];


        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            var connectionString = String.Format(DbConnection, ServerName, DatabaseName, Usercode, Password);
            var sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();
            return sqlConnection;
        }
    }
}