namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Common;
    using Data.Repositories;
    public class MajorsService : IMajorsService
    {
        private IRepository<Major> majors;

        public MajorsService(IRepository<Major> majors)
        {
            this.majors = majors;
        }

        public IQueryable<Major> All()
        {
            return this.majors.All();
        }

        public void Create(string name)
        {
            var major = new Major()
            {
                Name = name
            };

            this.majors.Add(major);
            this.majors.SaveChanges();
        }

        public void Delete(int id)
        {
            this.majors.Delete(id);
            this.majors.SaveChanges();
        }

        public Major GetById(int id)
        {
            return this.majors
                .All()
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Major> GetFiltered(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Major major)
        {
            throw new NotImplementedException();
        }
    }
}
