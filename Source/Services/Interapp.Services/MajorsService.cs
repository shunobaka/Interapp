namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class MajorsService : IMajorsService
    {
        private IDbRepository<Major> majors;

        public MajorsService(IDbRepository<Major> majors)
        {
            this.majors = majors;
        }

        public IQueryable<Major> All()
        {
            return this.majors.All();
        }

        public void Delete(int id)
        {
            var major = this.majors.GetById(id);
            this.majors.Delete(major);
            this.majors.Save();
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

        public void Update(Major major)
        {
            var originalMajor = this.majors.GetById(major.Id);

            if (originalMajor != null)
            {
                originalMajor.Name = major.Name;
                this.majors.Save();
            }
        }

        public Major Create(string name)
        {
            var major = new Major()
            {
                Name = name
            };

            this.majors.Add(major);
            this.majors.Save();

            return major;
        }
    }
}
