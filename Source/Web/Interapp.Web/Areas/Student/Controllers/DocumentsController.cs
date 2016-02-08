using System.Web.Mvc;

namespace Interapp.Web.Areas.Student.Controllers
{
    public class DocumentsController : Controller
    {

        public DocumentsController()
        {

        }

        public ActionResult All()
        {
            return View();
        }
    }
}