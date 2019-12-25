using System.Data.Entity;

namespace DataAccess.Seeders
{
    public interface ISeeder<in TContext> where TContext : DbContext
    {
        void SeedData(TContext context);
    }
}
