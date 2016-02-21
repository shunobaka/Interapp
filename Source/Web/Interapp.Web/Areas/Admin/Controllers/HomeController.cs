namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    public class HomeController : AdminController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}