namespace Interapp.Web.Areas.Student.Controllers
{
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;

    public class ApplicationsController : Controller
    {
        private IApplicationsService applications;

        public ApplicationsController(IApplicationsService applications)
        {
            this.applications = applications;
        }

        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var studentApplications = this.applications.AllByStudent(studentId);
            return View();
        }
    }
}