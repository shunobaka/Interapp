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

        public DocumentsController(IDocumentsService documents)
        {
            this.documents = documents;
        }

        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var model = this.documents
                .GetByStudent(studentId)
                .ProjectTo<DocumentViewModel>()
                .ToList();

            return View(model);
        }
    }
}