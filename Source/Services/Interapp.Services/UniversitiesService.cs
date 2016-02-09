namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Models;
    using Data.Repositories;
    using System.Data.Entity;
    public class UniversitiesService : IUniversitiesService
    {
        private IRepository<University> universities;

        public UniversitiesService(IRepository<University> universities)
        {
            this.universities = universities;
        }

        public IQueryable<University> All()
        {
            return this.universities.All();
        }

        public void Create(string directorId, string name, int tuitionFee, int countryId)
        {
            var university = new University()
            {
                CountryId = countryId,
                DirectorId = directorId,
                Name = name,
                TuitionFee = tuitionFee
            };

            this.universities.Add(university);
            this.universities.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.universities.Delete(id);
            this.universities.SaveChanges();
        }

        public University GetById(int id)
        {
            return this.universities.All()
                .Where(u => u.Id == id)
                .Include(u => u.Director)
                .FirstOrDefault();
        }

        public IQueryable<University> GetFiltered(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public void Update(University university)
        {
            this.universities.Update(university);
            this.universities.SaveChanges();
        }
    }
}
