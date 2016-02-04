namespace Interapp.Web
{
    using Data;
    using Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InterappDbContext, Configuration>());
            InterappDbContext.Create().Database.Initialize(true);
        }
    }
}