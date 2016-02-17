namespace Interapp.Web.Areas.Director.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.ApplicationsViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper;

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

        public ActionResult Details(int id)
        {
            var application = this.applications
                .GetById(id);

            var directorId = this.User.Identity.GetUserId();

            if (application == null || application.University.DirectorId != directorId)
            {
                return this.View();
            }

            var model = Mapper.Map<ApplicationDetailsViewModel>(application);

            return this.View(model);
        }
    }
}