namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models.ApplicationsViewModels;
    using Services.Contracts;

    public class ApplicationsController : DirectorController
    {
        private IApplicationsService applications;
        private IResponsesService responses;

        public ApplicationsController(IApplicationsService applications, IResponsesService responses)
        {
            this.applications = applications;
            this.responses = responses;
        }

        public ActionResult All()
        {
            var directorId = this.User.Identity.GetUserId();
            var model = this.applications
                .AllByDirector(directorId)
                .To<ApplicationViewModel>();

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var application = this.applications
                .GetById(id);

            var directorId = this.User.Identity.GetUserId();

            if (application == null || application.University.DirectorId != directorId)
            {
                return this.View();
            }

            this.applications.SetReviewed(id);

            var model = this.Mapper.Map<ApplicationDetailsViewModel>(application);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Evaluate(int id)
        {
            this.ViewData["app-id"] = id;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evaluate(int id, ResponseInputModel model)
        {
            var directorId = this.User.Identity.GetUserId();
            var isAuthorized = this.applications
                .All()
                .Any(a => a.University.DirectorId == directorId && a.Id == id);

            if (!isAuthorized)
            {
                this.ModelState.AddModelError("Authorization", "You are not authorized to edit this application!");
            }

            if (this.ModelState.IsValid)
            {
                this.responses.Create(id, model.Content, model.IsAdmitted);
                return this.RedirectToAction(nameof(this.All));
            }

            this.ViewData["app-id"] = id;
            return this.View(model);
        }
    }
}