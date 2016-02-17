namespace Interapp.Web.Areas.Director.Controllers
{
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
            return View();
        }
    }
}