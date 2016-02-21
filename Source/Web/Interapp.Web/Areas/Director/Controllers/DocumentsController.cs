namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;

    public class DocumentsController : DirectorController
    {
        private IDocumentsService documents;

        public DocumentsController(IDocumentsService documents)
        {
            this.documents = documents;
        }

        public ActionResult Index()
        {
            var directorId = this.User.Identity.GetUserId();
            var documentsList = this.documents.GetByDirector(directorId);
            return View();
        }
    }
}