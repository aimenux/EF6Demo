using System.Data.Entity;
using System.Data.SqlClient;

namespace DataAccess.Initializers
{
    public static class DatabaseInitializerExtensions
    {
        public static void CloseOpenedConnections<TContext>(this IDatabaseInitializer<TContext> initializer, TContext context = null) where TContext : DbContext 
        {
            SqlConnection.ClearAllPools();
            if (context == null) return;
            var databaseName = context.Database.Connection.Database;
            var sql = $"ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql);
        }
    }
}