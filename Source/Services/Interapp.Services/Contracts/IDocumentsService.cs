namespace Interapp.Services.Contracts
{
    using Data.Models;
    using System.Linq;

    public interface IDocumentsService
    {
        IQueryable<Document> GetByUniversity(int universityId);

        IQueryable<Document> GetByStudent(string studentId);

        void CreateForStudent(string studentId, string name, string content);

        void CreateForUniversity(int universityId, string name, string content);

        void Delete(int documentId);

        IQueryable<Document> GetRequiredForStudent(string studentId);

        Document GetById(int id);
    }
}
