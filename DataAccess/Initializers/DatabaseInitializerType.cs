namespace DataAccess.Initializers
{
    public enum DatabaseInitializerType
    {
        Nothing,
        DropCreateAlways,
        CreateIfNotExists,
        MigrateDatabaseToLatestVersion,
        ThrowPendingMigrationsException,
        DropCreateDatabaseIfModelChanges
    }
}
