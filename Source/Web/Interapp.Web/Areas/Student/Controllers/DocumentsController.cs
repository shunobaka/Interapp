namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Interapp.Services.Contracts;
    using Microsoft.AspNet.Identity;
    using Models.DocumentViewModels;
    using System.Linq;
    using System.Web.Mvc;

    public class DocumentsController : Controller
    {
        private IDocumentsService documents;
        private IUniversitiesService universities;

        public DocumentsController(IDocumentsService documents, IUniversitiesService universities)
        {
            this.documents = documents;
            this.universities = universities;
        }

        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var studentDocuments = this.documents
                .GetByStudent(studentId)
                .ProjectTo<DocumentViewModel>()
                .ToList();

            var universities = this.universities
                .GetForUserWithDocuments(studentId);
            // TODO: Finish and add model to view

            return View();
        }
    }
}