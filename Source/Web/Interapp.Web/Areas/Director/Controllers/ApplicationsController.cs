namespace Interapp.Web.Areas.Director.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.ApplicationsViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;

    [Authorize(Roles = "Director")]
    public class ApplicationsController : Controller
    {
        private IApplicationsService applications;

        public ApplicationsController(IApplicationsService applications)
        {
            this.applications = applications;
        }

        public ActionResult All()
        {
            var directorId = this.User.Identity.GetUserId();
            var model = this.applications
                .AllByDirector(directorId)
                .ProjectTo<ApplicationViewModel>();

            return View(model);
        }
    }
}