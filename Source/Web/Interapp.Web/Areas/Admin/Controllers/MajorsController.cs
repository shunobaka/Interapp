namespace Interapp.Web.Areas.Admin.Controllers
{
    using Models.MajorsViewModels;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using System.Web.Mvc;
    using Data.Models;
    using AutoMapper.QueryableExtensions;
    using System.Linq;

    public class MajorsController : Controller
    {
        private IMajorsService majors;

        public MajorsController(IMajorsService majors)
        {
            this.majors = majors;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MajorsRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.majors.All().ProjectTo<MajorViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MajorsCreate([DataSourceRequest]DataSourceRequest request, MajorViewModel major)
        {
            var majorExists = this.majors.All().Any(m => m.Name == major.Name);

            if (majorExists)
            {
                this.ModelState.AddModelError("Major exists", "Major will such name already exists.");
            }

            Major result = null;

            if (ModelState.IsValid)
            {
                result = this.majors.Create(major.Name);
            }

            if (result != null)
            {
                return Json(new[] { result }.ToDataSourceResult(request, ModelState));
            }

            return Json(new[] { major }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MajorsUpdate([DataSourceRequest]DataSourceRequest request, MajorViewModel major)
        {
            var majorExists = this.majors.All().Any(m => m.Name == major.Name);

            if (majorExists)
            {
                this.ModelState.AddModelError("Major exists", "Major will such name already exists.");
            }

            if (ModelState.IsValid)
            {
                var entity = new Major
                {
                    Id = major.Id,
                    Name = major.Name
                };

                this.majors.Update(entity);
            }

            return Json(new[] { major }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MajorsDestroy([DataSourceRequest]DataSourceRequest request, MajorViewModel major)
        {
            this.majors.Delete(major.Id);

            return Json(new[] { major }.ToDataSourceResult(request, ModelState));
        }
    }
}