using System;
using DataAccess.Contexts;

namespace DataAccess.Seeders
{
    public abstract class AbstractInsuranceSeeder<TContext> : 
        IInitializerSeeder<TContext>,
        IMigrationsSeeder<TContext>
        where TContext : AbstractDbContextForInsurance
    {
        protected abstract void SeedDataBody(TContext context);

        public void SeedData(TContext context)
        {
            try
            {
                SeedDataBody(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}