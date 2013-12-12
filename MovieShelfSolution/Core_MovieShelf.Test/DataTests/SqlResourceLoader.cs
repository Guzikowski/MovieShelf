using System.IO;
using System.Reflection;

namespace Core_MovieShelf.Test.DataTests
{
    public interface ISqlResourceLoader
    {
        /// <summary>
        /// Loads the SQL statement. This must be called from a concrete provider directly as we need the calling assembly
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        string LoadSqlStatement(string fileName);
    }
    public class SqlResourceLoader : ISqlResourceLoader
    {
        /// <summary>
        /// Loads the SQL statement. This must be called from a concrete provider directly as we need the calling assembly
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public string LoadSqlStatement(string fileName)
        {
            var sqlStatement = string.Empty;
            var allResources = Assembly.GetCallingAssembly().GetManifestResourceNames();
            foreach (var res in allResources)
            {
                if (!res.Contains(fileName)) continue;
                using (var stm = Assembly.GetCallingAssembly().GetManifestResourceStream(res))
                {
                    if (stm == null) continue;
                    sqlStatement = new StreamReader(stm).ReadToEnd();
                    break;
                }
            }
            return sqlStatement;
        }
    }
}
