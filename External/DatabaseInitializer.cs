using System.Data.Entity;
using System.Data.SqlClient;
using Entities;
using External.Migrations;

namespace External
{
    public class DatabaseInititializer
    {
        public static void Initialize(WW13DbContext dbContext)
        {
            //dbContext.Database.CreateIfNotExists();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WW13DbContext, Configuration>());

            try
            {
                dbContext.Database.Initialize(false);
            }
            catch (SqlException ex)
            {
                // we catch this exception to avoid a known (but unnecessary) SqlException in MiniProfiler, see http://stackoverflow.com/questions/11979026/entity-framework-5-expects-createdon-column-from-migrationhistory-table that requires a CreatedOn column
                if (ex.Message != "Invalid column name 'CreatedOn'.")
                {
                    throw;
                }
            }
        }
    }
}