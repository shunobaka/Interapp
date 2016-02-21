namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.DashboardViewModels;
    using Services.Contracts;

    public class DashboardController : StudentController
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

            var model = this.Mapper.Map<StudentInfoViewModel>(studentInfo);

            return this.View(model);
        }
    }
}