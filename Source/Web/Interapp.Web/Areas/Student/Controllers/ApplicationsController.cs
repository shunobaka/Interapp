namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.ApplicationsViewModels;
    using Services.Contracts;
    using System.Web.Mvc;

    [Authorize(Roles = "Student")]
    public class ApplicationsController : Controller
    {
        private IApplicationsService applications;
        private IStudentInfosService studentInfos;

        public ApplicationsController(IApplicationsService applications, IStudentInfosService studentInfos)
        {
            this.applications = applications;
            this.studentInfos = studentInfos;
        }

        [HttpGet]
        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var model = this.applications
                .AllByStudent(studentId)
                .ProjectTo<ApplicationViewModel>();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var application = this.applications
                .GetById(id);
            var studentId = this.User.Identity.GetUserId();

            if (application.StudentId != studentId)
            {
                return this.View();
            }

            var model = Mapper.Map<ApplicationDetailsViewModel>(application);

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Submit(ApplicationInputViewModel model)
        {
            var studentId = this.User.Identity.GetUserId();
            var eligiblity = this.studentInfos.IsEligibleToApply(studentId, model.UniversityId);

            if (!eligiblity.IsEligible)
            {
                this.ModelState.AddModelError("Eligiblity", eligiblity.Message);
            }

            if (this.ModelState.IsValid)
            {
                this.applications.Create(studentId, model.UniversityId, model.MajorId);
                return this.RedirectToAction(nameof(this.All));
            }

            return this.View(model);
        }
    }
}