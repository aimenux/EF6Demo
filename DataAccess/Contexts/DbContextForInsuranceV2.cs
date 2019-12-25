using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Contexts
{
    public class DbContextForInsuranceV2 : AbstractDbContextForInsurance
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("insurance");
            base.OnModelCreating(modelBuilder);
        }
    }
}