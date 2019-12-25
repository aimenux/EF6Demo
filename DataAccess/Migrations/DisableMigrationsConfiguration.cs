using System;
using System.Data.Entity;
using DataAccess.Seeders;

namespace DataAccess.Migrations
{
    public class DisableMigrationsConfiguration<TContext> : AbstractMigrationsConfiguration<TContext> where TContext : DbContext
    {
        public DisableMigrationsConfiguration() : base(false, false)
        {
        }
    }

    public class DisableMigrationsConfiguration<TContext,TSeeder> : AbstractMigrationsConfiguration<TContext> 
        where TContext : DbContext 
        where TSeeder : IMigrationsSeeder<TContext>, new()
    {
        private readonly TSeeder _migrationsSeeder;

        public DisableMigrationsConfiguration() : base(false, false)
        {
            _migrationsSeeder = new TSeeder();
        }

        protected override void Seed(TContext context)
        {
            Console.WriteLine("Seeding database from DisableMigrationsConfiguration");
            base.Seed(context);
            _migrationsSeeder?.SeedData(context);
        }
    }
}
