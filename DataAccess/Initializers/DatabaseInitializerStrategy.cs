using System;
using System.Data.Entity;
using System.Data.SqlClient;
using DataAccess.Migrations;
using DataAccess.Seeders;

namespace DataAccess.Initializers
{
    public static class DatabaseInitializerStrategy
    {
        public static void Initialize<TContext,TSeeder>(DatabaseInitializerType initializerType) 
            where TContext : DbContext 
            where TSeeder : IInitializerSeeder<TContext>, new()
        {
            SqlConnection.ClearAllPools();
            var initializer = Create<TContext,TSeeder>(initializerType);
            Database.SetInitializer(initializer);
        }

        private static IDatabaseInitializer<TContext> Create<TContext,TSeeder>(DatabaseInitializerType initializerType) 
            where TContext : DbContext
            where TSeeder : IInitializerSeeder<TContext>, new()
        {
            switch (initializerType)
            {
                case DatabaseInitializerType.Nothing:
                    return new NullDatabaseInitializer<TContext>();

                case DatabaseInitializerType.DropCreateAlways:
                    return new DropCreateDatabaseAlwaysInitializer<TContext,TSeeder>();

                case DatabaseInitializerType.CreateIfNotExists:
                    return new CreateDatabaseIfNotExistsInitializer<TContext,TSeeder>();

                case DatabaseInitializerType.MigrateDatabaseToLatestVersion:
                    return new MigrateDatabaseToLatestVersionInitializer<TContext,TSeeder,EnableMigrationsConfiguration<TContext>>();

                case DatabaseInitializerType.DropCreateDatabaseIfModelChanges:
                    return new DropCreateDatabaseIfModelChangesInitializer<TContext,TSeeder>();

                case DatabaseInitializerType.ThrowPendingMigrationsException:
                    return new NoPendingMigrationsInitializer<TContext,TSeeder,DisableMigrationsConfiguration<TContext>>();

                default:
                    throw new ArgumentOutOfRangeException($"Unsupported initializer type {initializerType}");
            }
        }
    }
}
