namespace Interapp.Web.Areas.Director.Controllers
{
    using Models;
    using System;
    using System.Web.Mvc;

    public class UniversitiesController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UniversityCreateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}