namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Documents;

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
            var model = this.documents
                .GetByDirector(directorId)
                .To<DocumentViewModel>();

            return this.View(model);
        }
    }
}