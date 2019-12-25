namespace DataAccess.Initializers
{
    public enum DatabaseInitializerType
    {
        Nothing,
        DropCreateAlways,
        CreateIfNotExists,
        NoPendingMigrations,
        MigrateDatabaseToLatestVersion,
        DropCreateDatabaseIfModelChanges
    }
}
