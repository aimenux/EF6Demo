using DataAccess.Contexts;

namespace DataAccess.Migrations
{
    public class InsuranceEnableMigrationsV1 : EnableMigrationsConfiguration<DbContextForInsuranceV1>
    {
    }

    public class InsuranceEnableMigrationsV2 : EnableMigrationsConfiguration<DbContextForInsuranceV2>
    {
    }

    public class InsuranceDisableMigrationsV1 : DisableMigrationsConfiguration<DbContextForInsuranceV1>
    {
    }

    public class InsuranceDisableMigrationsV2 : DisableMigrationsConfiguration<DbContextForInsuranceV2>
    {
    }
}
