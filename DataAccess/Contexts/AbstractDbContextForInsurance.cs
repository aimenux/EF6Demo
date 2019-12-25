using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Contexts
{
    public abstract class AbstractDbContextForInsurance : DbContext
    {
        protected AbstractDbContextForInsurance() : base(nameOrConnectionString: "DefaultConnection")
        {
        }

        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Provider> Providers { get; set; }
    }
}
