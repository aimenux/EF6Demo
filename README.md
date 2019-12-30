# EF6Demo
Code First with multiple initializers strategies :
- `Nothing`
- `DropCreateAlways`
- `CreateIfNotExists`
- `NoPendingMigrations`
- `MigrateDatabaseToLatestVersion`
- `DropCreateDatabaseIfModelChanges`


> ## Questions & Answers
>> `Question: What is the difference between Migrations Seed and Initializers Seed ?`
>>
>> [`Answer`](https://stackoverflow.com/questions/35241585/entity-framework-what-is-the-difference-between-migrations-seed-and-contextiniti):
>> - Migration Seed method is for seeding data right after database migration.
>> - Initializer Seed method is for seeding data right after database initialization.
>> - You can use Initializer Seed method to add initial data to DB right after initialization.
>> - You can use Migration Seed method to check and/or add new data or do special things right after migration.


You may apply automatic migration by either using code or using cli/ps commands.
- Using code, you need to set `DatabaseInitializerType` to `MigrateDatabaseToLatestVersion` in `program.cs`
- Using cli command (`Update-Database`), you need to specify an automatic migration configuration type :
  - `InsuranceEnableMigrationsV1`
  - `InsuranceEnableMigrationsV2`

> Update-Database Examples
>> Update-Database -Verbose -StartupProjectName App -ProjectName DataAccess -ConfigurationTypeName InsuranceEnableMigrationsV1

>> Update-Database -Verbose -StartupProjectName App -ProjectName DataAccess -ConfigurationTypeName InsuranceEnableMigrationsV2


**`Tools`** : `vs19, net framework 4.7.2, entity framework 6.4`
