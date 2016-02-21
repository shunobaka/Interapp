namespace Interapp.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class DbRepository<T> : IDbRepository<T>
        where T : class, IAuditInfo, IDeletableEntity
    {
        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public IQueryable<T> All()
        {
            return this.DbSet.Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return this.DbSet;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.Now;
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        public T Attach(T entity)
        {
            return this.Context.Set<T>().Attach(entity);
        }

        public void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public void Attach<TEntity>(TEntity entity)
            where TEntity : class
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
