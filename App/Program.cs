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
            Run<DbContextForInsuranceV1>();
            Console.WriteLine("Press any key to exit ..");
            Console.ReadKey();
        }

        private static void Run<TContext>() where TContext : AbstractDbContextForInsurance, new()
        {
            const DatabaseInitializerType initializerType = DatabaseInitializerType.CreateIfNotExists;

            DatabaseInitializerStrategy.Initialize<TContext,EmptyInsuranceSeeder<TContext>>(initializerType);

            using (var context = new TContext())
            {
                var insurances = context.Insurances.ToList();
                foreach (var toto in insurances)
                {
                    Console.WriteLine($"Insurance id {toto.Id} has code {toto.InsuranceCode}");
                }
            }
        }
    }
}
