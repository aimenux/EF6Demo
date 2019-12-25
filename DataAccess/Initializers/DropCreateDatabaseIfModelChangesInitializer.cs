using System;
using System.Data.Entity;
using DataAccess.Seeders;

namespace DataAccess.Initializers
{
    public class DropCreateDatabaseIfModelChangesInitializer<TContext,TSeeder> : DropCreateDatabaseIfModelChanges<TContext> 
        where TContext : DbContext
        where TSeeder : IInitializerSeeder<TContext>, new()
    {
        private readonly TSeeder _seeder;

        private const string InitializerName = "DropCreateDatabaseIfModelChangesInitializer";

        public DropCreateDatabaseIfModelChangesInitializer()
        {
            _seeder = new TSeeder();
        }

        public DropCreateDatabaseIfModelChangesInitializer(TSeeder seeder)
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
