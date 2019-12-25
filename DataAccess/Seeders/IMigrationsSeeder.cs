using System.Data.Entity;

namespace DataAccess.Seeders
{
    public interface IMigrationsSeeder<in TContext> : ISeeder<TContext> where TContext : DbContext
    {
    }
}