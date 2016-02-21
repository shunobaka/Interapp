namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Models.DashboardViewModels;
    using Services.Contracts;

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

            return this.View(model);
        }
    }
}