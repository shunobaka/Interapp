namespace Interapp.Web.Areas.Director.Controllers
{
    using Models;
    using Services.Contracts;
    using System;
    using System.Web.Mvc;

    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UniversityCreateViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                //var directorId = this.User.Identity.GetUserId();
                //this.universities.Create(directorId, model.)
                // TODO: Implement
            }
        }
    }
}