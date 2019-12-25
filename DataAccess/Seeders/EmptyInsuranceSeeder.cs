using System;
using DataAccess.Contexts;

namespace DataAccess.Seeders
{
    public class EmptyInsuranceSeeder<TContext> : AbstractInsuranceSeeder<TContext> where TContext : AbstractDbContextForInsurance
    {
        protected override void SeedDataBody(TContext context)
        {
            Console.WriteLine("Seeding database with EmptyInsuranceSeeder");
        }
    }
}