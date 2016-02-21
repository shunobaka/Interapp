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
        private IUniversitiesService universities;

        public DocumentsController(IDocumentsService documents, IUniversitiesService universities)
        {
            this.documents = documents;
            this.universities = universities;
        }

        public ActionResult Index()
        {
            var directorId = this.User.Identity.GetUserId();
            var model = this.documents
                .GetByDirector(directorId)
                .To<DocumentViewModel>();

            return this.View(model);
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DocumentInputViewModel model)
        {
            var university = this.universities.GetById(model.UniversityId);
            var directorId = this.User.Identity.GetUserId();

            if (university == null || university.DirectorId != directorId)
            {
                this.ModelState.AddModelError("Unauthorized", "You are not authorized to add document for this university.");
            }

            if (this.ModelState.IsValid)
            {
                this.documents.CreateForUniversity(model.UniversityId, model.Name);

                this.TempData["Message"] = "Document was successfully added.";
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }
    }
}