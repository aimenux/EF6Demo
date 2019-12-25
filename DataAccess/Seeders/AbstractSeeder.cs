using System;
using System.Data.Entity;

namespace DataAccess.Seeders
{
    public abstract class AbstractSeeder<TContext> : ISeeder<TContext> where TContext : DbContext
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