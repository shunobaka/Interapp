namespace Interapp.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class ApplicationsService : IApplicationsService
    {
        private IDbRepository<Application> applications;

        public ApplicationsService(IDbRepository<Application> applications)
        {
            this.applications = applications;
        }

        public IQueryable<Application> All()
        {
            return this.applications.All();
        }

        public IQueryable<Application> AllByDirector(string directorId)
        {
            return this.applications
                .All()
                .Where(a => a.University.Director.DirectorId == directorId)
                .Include(a => a.University);
        }

        public IQueryable<Application> AllByStudent(string studentId)
        {
            return this.applications
                .All()
                .Where(a => a.StudentId == studentId)
                .Include(a => a.University)
                .Include(a => a.University.Country);
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
                MajorId = majorId,
                StudentId = studentId,
                UniversityId = universityId,
                CreatedOn = DateTime.UtcNow
            };

            this.applications.Add(application);
            this.applications.Save();
        }

        public void Delete(int id)
        {
            var application = this.applications.GetById(id);
            this.applications.Delete(application);
            this.applications.Save();
        }

        public Application GetById(int id)
        {
            return this.applications
                .All()
                .Where(a => a.Id == id)
                .Include(a => a.University)
                .Include(a => a.Major)
                .Include(a => a.Student)
                .Include(a => a.Student.Scores)
                .Include(a => a.Student.Essay)
                .Include(a => a.Student.Student)
                .Include(a => a.University.Country)
                .Include(a => a.University.Director)
                .FirstOrDefault();
        }

        public IQueryable<Application> GetFilteredByUniversity(int universityId, FilterModel filter)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        public void SetReviewed(int id)
        {
            var application = this.applications
                .GetById(id);

            if (application != null)
            {
                application.IsReviewed = true;
            }
        }

        public void Update(Application application)
        {
            var orgApplication = this.applications.GetById(application.Id);

            if (orgApplication != null)
            {
                orgApplication.MajorId = application.MajorId;
                this.applications.Save();
            }
        }
    }
}
