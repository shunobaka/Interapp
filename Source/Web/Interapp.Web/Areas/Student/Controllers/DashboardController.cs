namespace Interapp.Web.Areas.Student.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;

    public class DashboardController : Controller
    {
        private IStudentInfosService studentInfos;

        public DashboardController(IStudentInfosService studentInfos)
        {
            this.studentInfos = studentInfos;
        }

        public ActionResult Info()
        {
            return View();
        }
    }
}