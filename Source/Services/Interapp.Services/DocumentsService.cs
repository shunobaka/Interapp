namespace Interapp.Services
{
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class DocumentsService : IDocumentsService
    {
        private IRepository<Document> documents;
        private IRepository<University> universities;

        public DocumentsService(IRepository<Document> documents, IRepository<University> universities)
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

            this.documents.SaveChanges();
        }
    }
}
