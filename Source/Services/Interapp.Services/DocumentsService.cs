namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Data.Models;
    using Interapp.Services.Contracts;
    using Data.Repositories;

    public class DocumentsService : IDocumentsService
    {
        private IRepository<Document> documents;

        public DocumentsService(IRepository<Document> documents)
        {
            this.documents = documents;
        }

        public void CreateForStudent(string studentId, string name, string content)
        {
            var document = new Document()
            {
                AuthorId = studentId,
                Content = content,
                Name = name
            };

            this.documents.Add(document);
            this.documents.SaveChanges();
        }

        public void CreateForUniversity(int universityId, string name, string content)
        {
            var document = new Document()
            {
                UniversityId = universityId,
                Content = content,
                Name = name
            };

            this.documents.Add(document);
            this.documents.SaveChanges();
        }

        public void Delete(int documentId)
        {
            this.documents.Delete(documentId);
            this.documents.SaveChanges();
        }

        public IQueryable<Document> GetByStudent(string studentId)
        {
            return this.documents
                .All()
                .Where(d => d.AuthorId == studentId);
        }

        public IQueryable<Document> GetByUniversity(int universityId)
        {
            return this.documents
                .All()
                .Where(d => d.UniversityId == universityId);
        }
    }
}
