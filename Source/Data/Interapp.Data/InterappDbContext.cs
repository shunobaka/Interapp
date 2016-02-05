namespace Interapp.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class InterappDbContext : IdentityDbContext<User>, IInterappDbContext
    {
        public InterappDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Application> Applications { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Document> Documents { get; set; }

        public IDbSet<Essay> Essays { get; set; }

        public IDbSet<Major> Majors { get; set; }

        public IDbSet<ScoreReport> ScoreReports { get; set; }

        public IDbSet<University> Universities { get; set; }

        public IDbSet<DirectorInfo> DirectorInfos { get; set; }

        public IDbSet<StudentInfo> StudentInfos { get; set; }

        public IDbSet<Response> Responses { get; set; }

        public static InterappDbContext Create()
        {
            return new InterappDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(u => u.DirectorInfo)
                .WithRequired(d => d.Director);

            modelBuilder.Entity<User>()
                .HasOptional(u => u.StudentInfo)
                .WithRequired(d => d.Student);

            modelBuilder.Entity<StudentInfo>()
                .HasOptional(u => u.Essay)
                .WithRequired(e => e.Author);

            modelBuilder.Entity<StudentInfo>()
                .HasOptional(u => u.Scores)
                .WithRequired(e => e.StudentInfo);

            modelBuilder.Entity<User>()
                .HasRequired(u => u.Country)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Application>()
                .HasRequired(a => a.University)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
