namespace Interapp.Web.Areas.Student.Controllers
{
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
            var universities = studentInfo.UniversitiesOfInterest.AsQueryable().ProjectTo<UniversityViewModel>().ToList();

            var model = new DocumentsFullViewModel()
            {
                StudentDocuments = studentDocuments,
                Universities = universities
            };

            return View(model);
        }
    }
}