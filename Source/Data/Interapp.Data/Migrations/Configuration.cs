namespace Interapp.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<InterappDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InterappDbContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var admin = new IdentityRole { Name = "Administrator" };
                manager.Create(admin);

                var director = new IdentityRole { Name = "Director" };
                manager.Create(director);

                var student = new IdentityRole { Name = "Student" };
                manager.Create(student);
            }
        }
    }
}
