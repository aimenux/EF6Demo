using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccess.Contexts
{
    public class DbContextForInsuranceV1 : AbstractDbContextForInsurance
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(18, 3));
            base.OnModelCreating(modelBuilder);
        }
    }
}
