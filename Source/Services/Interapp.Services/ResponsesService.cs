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

        public ResponsesService(IRepository<Response> responses)
        {
            this.responses = responses;
        }

        public void Create(int applicationId, string content, bool IsAdmitted)
        {
            var response = new Response()
            {
                ApplicationId = applicationId,
                Content = content,
                Date = DateTime.UtcNow,
                IsAdmitted = IsAdmitted
            };

            this.responses.Add(response);
            this.responses.SaveChanges();
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
