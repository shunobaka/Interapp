namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Director")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}