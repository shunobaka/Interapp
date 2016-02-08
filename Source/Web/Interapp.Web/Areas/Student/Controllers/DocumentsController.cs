namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Interapp.Services.Contracts;
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
            var studentId = this.User.Identity.GetUserId();
            var studentDocuments = this.documents.GetByStudent(studentId);

            if (studentDocuments == null)
            {
                return this.View();
            }

            var document = studentDocuments.Where(d => d.Id == id).FirstOrDefault();
            var model = Mapper.Map<DocumentViewModel>(document);

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
            var studentDocuments = this.documents.GetByStudent(studentId);

            if (studentDocuments == null)
            {
                return this.View();
            }

            var document = studentDocuments.Where(d => d.Id == id).FirstOrDefault();
            var model = Mapper.Map<DocumentViewModel>(document);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Edit(DocumentViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                this.documents.CreateForStudent(studentId, model.Name, model.Content);

                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model);
        }
    }
}