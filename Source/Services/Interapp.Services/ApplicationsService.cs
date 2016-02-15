namespace Interapp.Services
{
    using Contracts;
    using System;
    using Data.Models;
    using Common;
    using System.Linq;
    using Data.Repositories;

    public class ApplicationsService : IApplicationsService
    {
        private IRepository<Application> applications;

        public ApplicationsService(IRepository<Application> applications)
        {
            this.applications = applications;
        }

        public IQueryable<Application> All()
        {
            return this.applications.All();
        }

        public IQueryable<Application> AllByUniversity(int universityId)
        {
            return this.applications
                .All()
                .Where(a => a.UniversityId == universityId);
        }

        public void Create(string studentId, int universityId, int majorId)
        {
            var application = new Application()
            {
                DateCreated = DateTime.UtcNow,
                MajorId = majorId,
                StudentId = studentId,
                UniversityId = universityId
            };

            this.applications.Add(application);
            this.applications.SaveChanges();
        }

        public void Delete(int id)
        {
            this.applications.Delete(id);
            this.applications.SaveChanges();
        }

        public Application GetById(int id)
        {
            return this.applications
                .All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Application> GetFilteredByUniversity(int universityId, FilterModel filter)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
