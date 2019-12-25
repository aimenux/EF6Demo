using System;
using System.Linq;
using DataAccess.Contexts;
using DataAccess.Initializers;
using DataAccess.Seeders;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            Run<DbContextForInsuranceV1>(true);
            Console.WriteLine("Press any key to exit ..");
            Console.ReadKey();
        }

        private static void Run<TContext>(bool withSeeder) where TContext : AbstractDbContextForInsurance, new()
        {
            const DatabaseInitializerType initializerType = DatabaseInitializerType.DropCreateAlways;

            if (withSeeder)
            {
                DatabaseInitializerStrategy.Initialize<TContext, RandomInsuranceSeeder<TContext>>(initializerType);
            }
            else
            {
                DatabaseInitializerStrategy.Initialize<TContext, EmptyInsuranceSeeder<TContext>>(initializerType);
            }

            using (var context = new TContext())
            {
                var providers = context.Providers.ToList();
                foreach (var provider in providers)
                {
                    Console.WriteLine($"Provider id {provider.Id} has code {provider.ProviderCode}");
                }

                var insurances = context.Insurances.ToList();
                foreach (var insurance in insurances)
                {
                    Console.WriteLine($"Insurance id {insurance.Id} has code {insurance.InsuranceCode}");
                }
            }
        }
    }
}
