﻿namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class ResponsesService : IResponsesService
    {
        private IDbRepository<Response> responses;
        private IDbRepository<Application> applications;

        public ResponsesService(IDbRepository<Response> responses, IDbRepository<Application> applications)
        {
            this.responses = responses;
            this.applications = applications;
        }

        public void Create(int applicationId, string content, bool isAdmitted)
        {
            var application = this.applications.GetById(applicationId);

            if (application != null)
            {
                var response = new Response()
                {
                    Content = content,
                    IsAdmitted = isAdmitted,
                    CreatedOn = DateTime.UtcNow
                };

                application.Response = response;
                application.IsAnswered = true;
                this.applications.Save();
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

        public IQueryable<Response> All()
        {
            return this.responses.All();
        }

        public void Update(Response response)
        {
            var orgResponse = this.responses.GetById(response.ApplicationId);

            if (orgResponse != null)
            {
                orgResponse.Content = response.Content;
                orgResponse.IsAdmitted = response.IsAdmitted;
                this.responses.Save();
            }
        }

        public void Delete(int id)
        {
            var response = this.responses.GetById(id);
            this.responses.Delete(response);
            this.responses.Save();
        }
    }
}
