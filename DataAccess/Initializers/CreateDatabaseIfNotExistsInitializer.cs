using System;
using System.Data.Entity;
using DataAccess.Seeders;

namespace DataAccess.Initializers
{
    public class CreateDatabaseIfNotExistsInitializer<TContext,TSeeder> : CreateDatabaseIfNotExists<TContext> 
        where TContext : DbContext
        where TSeeder : IInitializerSeeder<TContext>, new()
    {
        private readonly TSeeder _seeder;

        private const string InitializerName = "CreateDatabaseIfNotExistsInitializer";

        public CreateDatabaseIfNotExistsInitializer()
        {
            _seeder = new TSeeder();
        }

        public CreateDatabaseIfNotExistsInitializer(TSeeder seeder)
        {
            _seeder = seeder;
        }

        public override void InitializeDatabase(TContext context)
        {
            Console.WriteLine($"Initializing database using {InitializerName}");
            base.InitializeDatabase(context);
        }

        protected override void Seed(TContext context)
        {
            Console.WriteLine($"Seeding database from {InitializerName}");
            base.Seed(context);
            _seeder?.SeedData(context);
        }
    }
}
