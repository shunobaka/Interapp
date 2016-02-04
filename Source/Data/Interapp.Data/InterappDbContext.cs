namespace Interapp.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class InterappDbContext : IdentityDbContext<User>
    {
        public InterappDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Document> Documents { get; set; }

        public IDbSet<Essay> Essays { get; set; }

        public IDbSet<Major> Majors { get; set; }

        public IDbSet<Score> Scores { get; set; }

        public IDbSet<University> Universities { get; set; }

        public static InterappDbContext Create()
        {
            return new InterappDbContext();
        }
    }
}
