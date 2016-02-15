namespace Interapp.Web
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<InterappDbContext, Configuration>());
            InterappDbContext.Create().Database.Initialize(true);
        }
    }
}