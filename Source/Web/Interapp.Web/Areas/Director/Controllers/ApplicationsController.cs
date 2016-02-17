namespace Interapp.Web.Areas.Director.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.ApplicationsViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper;
    using System;

    [Authorize(Roles = "Director")]
    public class ApplicationsController : Controller
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
                .ProjectTo<ApplicationViewModel>();

            return View(model);
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

            var model = Mapper.Map<ApplicationDetailsViewModel>(application);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Evaluate(int id)
        {
            ViewData["app-id"] = id;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Evaluate(int id, ResponseInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                this.responses.Create(id, model.Content, model.IsAdmitted);
                return this.RedirectToAction(nameof(this.All));
            }

            ViewData["app-id"] = id;
            return this.View(model);
        }
    }
}