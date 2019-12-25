using System;
using System.Data.Entity;
using DataAccess.Seeders;

namespace DataAccess.Migrations
{
    public class EnableMigrationsConfiguration<TContext> : AbstractMigrationsConfiguration<TContext> where TContext : DbContext
    {
        public EnableMigrationsConfiguration() : base(true, true)
        {
        }
    }

    public class EnableMigrationsConfiguration<TContext,TSeeder> : AbstractMigrationsConfiguration<TContext> 
        where TContext : DbContext 
        where TSeeder : IMigrationsSeeder<TContext>, new()
    {
        private readonly TSeeder _migrationsSeeder;

        public EnableMigrationsConfiguration() : base(true, true)
        {
            _migrationsSeeder = new TSeeder();
        }

        protected override void Seed(TContext context)
        {
            Console.WriteLine("Seeding database from EnableMigrationsConfiguration");
            base.Seed(context);
            _migrationsSeeder?.SeedData(context);
        }
    }
}
