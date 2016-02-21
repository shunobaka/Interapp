namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Majors;

    public class MajorsController : AdminController
    {
        private IMajorsService majors;

        public MajorsController(IMajorsService majors)
        {
            this.majors = majors;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult MajorsRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.majors.All().To<MajorViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
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

            if (this.ModelState.IsValid)
            {
                result = this.majors.Create(major.Name);
            }

            if (result != null)
            {
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { major }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MajorsUpdate([DataSourceRequest]DataSourceRequest request, MajorViewModel major)
        {
            var majorExists = this.majors.All().Any(m => m.Name == major.Name);

            if (majorExists)
            {
                this.ModelState.AddModelError("Major exists", "Major will such name already exists.");
            }

            if (this.ModelState.IsValid)
            {
                var entity = new Major
                {
                    Id = major.Id,
                    Name = major.Name
                };

                this.majors.Update(entity);
            }

            return this.Json(new[] { major }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MajorsDestroy([DataSourceRequest]DataSourceRequest request, MajorViewModel major)
        {
            this.majors.Delete(major.Id);

            return this.Json(new[] { major }.ToDataSourceResult(request, this.ModelState));
        }
    }
}