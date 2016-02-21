namespace Interapp.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IResponsesService
    {
        Response GetById(int id);

        IQueryable<Response> GetByStudent(string studentId);

        IQueryable<Response> GetByUniversity(int universityId);

        void Create(int applicationId, string content, bool IsAdmitted);
    }
}
