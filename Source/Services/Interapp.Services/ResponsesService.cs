namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class ResponsesService : IResponsesService
    {
        private IRepository<Response> responses;
        private IRepository<Application> applications;

        public ResponsesService(IRepository<Response> responses, IRepository<Application> applications)
        {
            this.responses = responses;
            this.applications = applications;
        }

        public void Create(int applicationId, string content, bool IsAdmitted)
        {
            var application = this.applications.GetById(applicationId);

            if (application != null)
            {
                var response = new Response()
                {
                    Content = content,
                    Date = DateTime.UtcNow,
                    IsAdmitted = IsAdmitted
                };

                application.Response = response;
                application.IsAnswered = true;
                this.applications.SaveChanges();
            }
        }

        public Response GetById(int id)
        {
            return this.responses
                .All()
                .Where(r => r.ApplicationId == id)
                .FirstOrDefault();
        }

        public IQueryable<Response> GetByStudent(string studentId)
        {
            return this.responses
                .All()
                .Where(r => r.Application.StudentId == studentId);
        }

        public IQueryable<Response> GetByUniversity(int universityId)
        {
            return this.responses
                .All()
                .Where(r => r.Application.UniversityId == universityId);
        }
    }
}
