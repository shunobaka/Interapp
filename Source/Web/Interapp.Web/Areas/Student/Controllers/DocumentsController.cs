namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Documents;

    public class DocumentsController : StudentController
    {
        private IDocumentsService documents;
        private IUniversitiesService universities;
        private IStudentInfosService students;

        public DocumentsController(IDocumentsService documents, IUniversitiesService universities, IStudentInfosService students)
        {
            this.students = students;
            this.documents = documents;
            this.universities = universities;
        }

        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var studentInfo = this.students.GetFullInfoById(studentId);

            var studentDocuments = studentInfo.Documents.AsQueryable().To<DocumentViewModel>().ToList();
            var requiredDocuments = this.documents
                .GetRequiredForStudent(studentId)
                .To<DocumentViewModel>()
                .ToList();

            var model = new DocumentsListViewModel()
            {
                StudentDocuments = studentDocuments,
                RequiredDocuments = requiredDocuments
            };

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var studentId = this.User.Identity.GetUserId();
            var document = this.documents.GetById(id);

            if (document == null || document.AuthorId != studentId)
            {
                return this.View();
            }

            var model = this.Mapper.Map<DocumentViewModel>(document);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                this.documents.CreateForStudent(studentId, model.Name, model.Content);

                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var studentId = this.User.Identity.GetUserId();
            var document = this.documents.GetById(id);

            if (document == null || document.AuthorId != studentId)
            {
                return this.View();
            }

            var model = this.Mapper.Map<DocumentViewModel>(document);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentViewModel model)
        {
            var original = this.documents.GetById(model.Id);
            var studentId = this.User.Identity.GetUserId();

            if (original.AuthorId != studentId)
            {
                this.ModelState.AddModelError("Oh snap!", "You are not authorized to edit this document!");
            }

            if (this.ModelState.IsValid)
            {
                var document = this.Mapper.Map<Document>(model);
                this.documents.Update(document);

                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model);
        }
    }
}