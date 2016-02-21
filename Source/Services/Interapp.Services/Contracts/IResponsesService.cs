namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IResponsesService
    {
        IQueryable<Response> All();

        void Update(Response response);

        void Delete(int id);

        Response GetById(int id);

        IQueryable<Response> GetByStudent(string studentId);

        IQueryable<Response> GetByUniversity(int universityId);

        void Create(int applicationId, string content, bool isAdmitted);
    }
}
