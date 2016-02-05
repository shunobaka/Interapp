namespace Interapp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IInterappDbContext : IDisposable
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Application> Applications { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Document> Documents { get; set; }

        IDbSet<Essay> Essays { get; set; }

        IDbSet<Major> Majors { get; set; }

        IDbSet<ScoreReport> ScoreReports { get; set; }

        IDbSet<University> Universities { get; set; }

        IDbSet<DirectorInfo> DirectorInfoes { get; set; }

        IDbSet<StudentInfo> StudentInfoes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
