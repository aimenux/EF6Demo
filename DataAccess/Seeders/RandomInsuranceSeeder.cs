using System;
using System.Collections.Generic;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Helpers;

namespace DataAccess.Seeders
{
    public class RandomInsuranceSeeder<TContext> : AbstractInsuranceSeeder<TContext> where TContext : AbstractDbContextForInsurance
    {
        private readonly IRandomGenerator _randomGenerator;

        public RandomInsuranceSeeder() : this(new RandomGenerator())
        {
        }

        public RandomInsuranceSeeder(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        protected override void SeedDataBody(TContext context)
        {
            Console.WriteLine("Seeding database with RandomInsuranceSeeder");

            var rate = _randomGenerator.RandomRate();
            var code = _randomGenerator.RandomString();

            var provider = new Provider
            {
                ProviderRate = rate,
                ProviderCode = $"P_{code}",
                Insurances = new List<Insurance>()
            };

            var insurance = new Insurance
            {
                InsuranceProvider = provider,
                InsuranceCode = $"I_{code}",
                Enabled = true
            };

            provider.Insurances.Add(insurance);
            context.Providers.Add(provider);

            context.Insurances.Add(insurance);
            context.SaveChanges();
        }
    }
}
