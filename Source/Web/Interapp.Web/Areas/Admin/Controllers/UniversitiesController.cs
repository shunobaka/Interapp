namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Universities;

    public class UniversitiesController : AdminController
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult UniversitiesRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.universities.All().To<UniversityViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UniversitiesUpdate([DataSourceRequest]DataSourceRequest request, UniversityViewModel university)
        {
            var universityExists = this.universities.All().Any(m => m.Name == university.Name);

            if (universityExists)
            {
                this.ModelState.AddModelError("University exists", "University with such name already exists.");
            }

            if (this.ModelState.IsValid)
            {
                var entity = new University
                {
                    Id = university.Id,
                    Name = university.Name,
                    TuitionFee = university.TuitionFee,
                    RequiredCambridgeLevel = university.RequiredCambridgeLevel,
                    RequiredCambridgeScore = university.RequiredCambridgeScore,
                    RequiredIBTToefl = university.RequiredIBTToefl,
                    RequiredPBTToefl = university.RequiredPBTToefl,
                    RequiredSAT = university.RequiredSAT
                };

                this.universities.Update(entity);
            }

            return this.Json(new[] { university }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UniversitiesDestroy([DataSourceRequest]DataSourceRequest request, UniversityViewModel university)
        {
            this.universities.Delete(university.Id);

            return this.Json(new[] { university }.ToDataSourceResult(request, this.ModelState));
        }
    }
}