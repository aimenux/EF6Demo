# EF6Demo
Code First with multiple migrations strategies

`Question: What is the difference between Migrations Seed and Initializers Seed ?`

[`Answer`](https://stackoverflow.com/questions/35241585/entity-framework-what-is-the-difference-between-migrations-seed-and-contextiniti):
- Migration Seed method is for seeding data right after database migration.
- Initializer Seed method is for seeding data right after database initialization.
- You can use Initializer Seed method to add initial data to DB right after initialization.
- You can use Migration Seed method to check and/or add new data or do special things right after migration.

`To apply automatic migration from package manager console, run this command (specify an automatic migration either V1 or V2) :`
> Update-Database -Verbose -StartupProjectName App -ProjectName DataAccess -ConfigurationTypeName InsuranceEnableMigrationsV2
