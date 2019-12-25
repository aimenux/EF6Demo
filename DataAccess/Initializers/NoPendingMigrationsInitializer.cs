using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using DataAccess.Seeders;

namespace DataAccess.Initializers
{
    public class NoPendingMigrationsInitializer<TContext,TSeeder,TMigrationsConfiguration> : IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TSeeder : IInitializerSeeder<TContext>, new()
        where TMigrationsConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly TSeeder _seeder;
        private readonly TMigrationsConfiguration _config;

        private const string InitializerName = "NoPendingMigrationsInitializer";

        public NoPendingMigrationsInitializer()
        {
            _seeder = new TSeeder();
            _config = new TMigrationsConfiguration();
        }

        public NoPendingMigrationsInitializer(TSeeder seeder) : this()
        {
            _seeder = seeder;
        }

        public void InitializeDatabase(TContext context)
        {
            Console.WriteLine($"Initializing database using {InitializerName}");

            if (!context.Database.Exists())
            {
                throw new InvalidOperationException("The database does not exist");
            }

            if (!context.Database.CompatibleWithModel(true))
            {
                throw new InvalidOperationException("The database is not compatible with the entity model");
            }

            var migrator = new DbMigrator(_config);
            var migrations = migrator
                .GetPendingMigrations()
                .ToList();

            if (!migrations.Any())
            {
                Console.WriteLine($"Seeding database from {InitializerName}");
                _seeder?.SeedData(context);
                return;
            }

            var message = $"There are pending migrations {string.Join("\r\n", migrations)} that must be applied before starting application";
            throw new MigrationsPendingException(message);
        }
    }
}
