namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IDocumentsService
    {
        IQueryable<Document> GetByUniversity(int universityId);

        IQueryable<Document> GetByStudent(string studentId);

        IQueryable<Document> GetByDirector(string directorId);

        void CreateForStudent(string studentId, string name, string content);

        void CreateForUniversity(int universityId, string name);

        void Delete(int documentId);

        IQueryable<Document> GetRequiredForStudent(string studentId);

        Document GetById(int id);

        void Update(Document document);
    }
}
