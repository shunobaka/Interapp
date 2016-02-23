namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Countries;

    public class CountriesController : AdminController
    {
        private ICountriesService countries;

        public CountriesController(ICountriesService countries)
        {
            this.countries = countries;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult CountriesRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.countries.All().To<CountryViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CountriesCreate([DataSourceRequest]DataSourceRequest request, CountryViewModel country)
        {
            var countryExists = this.countries.All().Any(m => m.Name == country.Name);

            if (countryExists)
            {
                this.ModelState.AddModelError("Major exists", "Major with such name already exists.");
            }

            Country result = null;

            if (this.ModelState.IsValid)
            {
                result = this.countries.Create(country.Name);
            }

            if (result != null)
            {
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { country }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CountriesUpdate([DataSourceRequest]DataSourceRequest request, CountryViewModel country)
        {
            var countryExists = this.countries.All().Any(m => m.Name == country.Name);

            if (countryExists)
            {
                this.ModelState.AddModelError("Major exists", "Major will such name already exists.");
            }

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Country>(country);
                this.countries.Update(entity);
            }

            return this.Json(new[] { country }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CountriesDestroy([DataSourceRequest]DataSourceRequest request, CountryViewModel country)
        {
            this.countries.Delete(country.Id);

            return this.Json(new[] { country }.ToDataSourceResult(request, this.ModelState));
        }
    }
}