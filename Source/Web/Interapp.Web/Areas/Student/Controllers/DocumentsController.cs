namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Interapp.Services.Contracts;
    using Models.Shared;
    using Microsoft.AspNet.Identity;
    using Models.DocumentViewModels;
    using Models.UniversityViewModels;
    using System.Linq;
    using System.Web.Mvc;

    public class DocumentsController : Controller
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
            //var studentId = this.User.Identity.GetUserId();
            //var studentDocuments = this.documents
            //    .GetByStudent(studentId)
            //    .ProjectTo<DocumentViewModel>()
            //    .ToList();

            //var universities = this.universities
            //    .GetForUserWithDocuments(studentId);
            // TODO: Finish and add model to view
            var studentId = this.User.Identity.GetUserId();
            var studentInfo = this.students.GetFullInfoById(studentId);

            var studentDocuments = studentInfo.Documents.AsQueryable().ProjectTo<DocumentViewModel>().ToList();
            var requiredDocuments = this.documents
                .GetRequiredForStudent(studentId)
                .ProjectTo<DocumentViewModel>()
                .ToList();

            var model = new DocumentsFullViewModel()
            {
                StudentDocuments = studentDocuments,
                RequiredDocuments = requiredDocuments
            };

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var studentId = this.User.Identity.GetUserId();
                var document = this.documents.GetById((int)id);

                if (document == null || document.AuthorId != studentId)
                {
                    return this.View();
                }

                var model = Mapper.Map<DocumentViewModel>(document);

                return this.View(model);
            }

            return this.View();
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
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var studentId = this.User.Identity.GetUserId();
                var document = this.documents.GetById((int)id);

                if (document == null || document.AuthorId != studentId)
                {
                    return this.View();
                }

                var model = Mapper.Map<DocumentViewModel>(document);

                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocumentViewModel model)
        {
            var original = this.documents.GetById(model.Id);
            var studentId = this.User.Identity.GetUserId();

            if (original.AuthorId != studentId)
            {
                this.ModelState.AddModelError("Oh snap!", "You are not authorized to edit this document!!!");
            }

            if (this.ModelState.IsValid)
            {
                var document = new Document()
                {
                    Name = model.Name,
                    Id = model.Id,
                    Content = model.Content
                };
                this.documents.Update(document);
           
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = new DeleteInfoViewModel()
            {
                ControllerName = "Documents",
                ItemName = "document",
                ItemId = id
            };
            return this.View(model);
        }

        public ActionResult Deleted()
        {
            var model = new DeleteInfoViewModel()
            {
                ControllerName = "Documents",
                ItemName = "document"
            };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var document = this.documents.GetById(id);
            var studentId = this.User.Identity.GetUserId();

            if (document.AuthorId != studentId)
            {
                return this.View("Unathorized");
            }

            this.documents.Delete(id);

            return this.RedirectToAction(nameof(this.Deleted));
        }
    }
}