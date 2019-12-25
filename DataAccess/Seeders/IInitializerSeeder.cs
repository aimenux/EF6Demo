using System.Data.Entity;

namespace DataAccess.Seeders
{
    public interface IInitializerSeeder<in TContext> : ISeeder<TContext> where TContext : DbContext
    {
    }
}