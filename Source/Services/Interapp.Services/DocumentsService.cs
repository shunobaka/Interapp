namespace Interapp.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class DocumentsService : IDocumentsService
    {
        private IDbRepository<Document> documents;
        private IDbRepository<University> universities;

        public DocumentsService(IDbRepository<Document> documents, IDbRepository<University> universities)
        {
            this.documents = documents;
            this.universities = universities;
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
            this.documents.Save();
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
            this.documents.Save();
        }

        public void Delete(int documentId)
        {
            var document = this.documents.GetById(documentId);
            this.documents.Delete(document);
            this.documents.Save();
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

        public IQueryable<Document> GetRequiredForStudent(string studentId)
        {
            // TODO: Check logic
            var requiredDocuments = this.documents.All()
                .Where(d => d.University != null &&
                    d.University.InterestedStudents
                        .FirstOrDefault(s => s.StudentId == studentId) != null &&
                    !d.University.InterestedStudents
                        .FirstOrDefault(s => s.StudentId == studentId).Documents.Any(sd => sd.Name == d.Name))
                .Include(d => d.University);

            return requiredDocuments;
        }

        public Document GetById(int id)
        {
            return this.documents
                .All()
                .Where(d => d.Id == id)
                .FirstOrDefault();
        }

        public void Update(Document document)
        {
            var original = this.documents
                .All()
                .Where(d => d.Id == document.Id)
                .FirstOrDefault();

            if (original != null)
            {
                original.Name = document.Name;
                original.Content = document.Content;
            }

            this.documents.Save();
        }

        public IQueryable<Document> GetByDirector(string directorId)
        {
            return this.documents
                .All()
                .Where(d => d.University != null && d.University.DirectorId == directorId)
                .Include(d => d.University);
        }
    }
}
