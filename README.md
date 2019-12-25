# EF6Demo
Code First with multiple migrations strategies

`Question: What is the difference between Migrations Seed and ContextInitializer Seed ?`

[`Answer`](https://stackoverflow.com/questions/35241585/entity-framework-what-is-the-difference-between-migrations-seed-and-contextiniti):
- Migration Seed method is for seeding data right after database migration.
- DB Initializer Seed method is for seeding data right after Database initialization.
- You can use Db Initialize Seed method to add initial data to DB right after Initialization.
- You can use Migration Seed method to check and/or add new data or do special things right after Migration.

> Update-Database -Verbose -StartupProjectName App -ProjectName DataAccess -ConfigurationTypeName EnableMigrationsConfiguration
