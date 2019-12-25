using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataAccess.Seeders;

namespace DataAccess.Initializers
{
    public class MigrateDatabaseToLatestVersionInitializer<TContext,TSeeder,TMigrationsConfiguration> : MigrateDatabaseToLatestVersion<TContext,TMigrationsConfiguration> 
        where TContext : DbContext
        where TSeeder : IInitializerSeeder<TContext>, new()
        where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly TSeeder _seeder;

        private const string InitializerName = "DropCreateDatabaseIfModelChangesInitializer";

        public MigrateDatabaseToLatestVersionInitializer()
        {
            _seeder = new TSeeder();
        }

        public MigrateDatabaseToLatestVersionInitializer(TSeeder seeder)
        {
            _seeder = seeder;
        }

        public override void InitializeDatabase(TContext context)
        {
            Console.WriteLine($"Initializing database using {InitializerName}");
            base.InitializeDatabase(context);

            Console.WriteLine($"Seeding database from {InitializerName}");
            _seeder?.SeedData(context);
        }
    }
}
