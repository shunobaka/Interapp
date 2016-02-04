namespace Interapp.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IInterappDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }
        IDbSet<Application> Applications { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Document> Documents { get; set; }

        IDbSet<Essay> Essays { get; set; }

        IDbSet<Major> Majors { get; set; }

        IDbSet<University> Universities { get; set; }

        IDbSet<DirectorInfo> DirectorInfoes { get; set; }

        IDbSet<StudentInfo> StudentInfoes { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
