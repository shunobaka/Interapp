namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IResponsesService
    {
        Response GetById(int id);

        IQueryable<Response> GetByStudent(string studentId);

        IQueryable<Response> GetByUniversity(int universityId);

        void Create(int applicationId, string content, bool isAdmitted);
    }
}
