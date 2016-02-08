namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using Models.StudentInfoViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;

    [Authorize(Roles = "Student")]
    public class DashboardController : Controller
    {
        private IStudentInfosService studentInfos;

        public DashboardController(IStudentInfosService studentInfos)
        {
            this.studentInfos = studentInfos;
        }

        public ActionResult Info()
        {
            var userId = this.User.Identity.GetUserId();
            var studentInfo = this.studentInfos.GetFullInfoById(userId);

            var model = Mapper.Map<StudentInfoViewModel>(studentInfo);

            return View(model);
        }
    }
}