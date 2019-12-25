using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DataAccess.Migrations
{
    public abstract class AbstractMigrationsConfiguration<TContext> : DbMigrationsConfiguration<TContext> where TContext : DbContext
    {
        protected AbstractMigrationsConfiguration(bool automaticMigrationsEnabled, bool automaticMigrationDataLossAllowed)
        {
            AutomaticMigrationsEnabled = automaticMigrationsEnabled;
            AutomaticMigrationDataLossAllowed = automaticMigrationDataLossAllowed;
        }
    }
}
