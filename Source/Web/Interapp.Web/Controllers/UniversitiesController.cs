namespace Interapp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Common;
    using Services.Contracts;
    using ViewModels.Universities;

    [Authorize]
    public class UniversitiesController : BaseController
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult All(FilterModel model)
        {
            var universitiesList =
                this.Cache.Get(
                    "Universities",
                    () => this.universities.AllWithCountry().ToList(),
                    30 * 60);

            var filteredUnis = this.universities
                .FilterUniversities(universitiesList.AsQueryable(), model)
                .To<UniversitySimpleViewModel>()
                .ToList();

            var viewDataModel = new UniversitiesListViewModel()
            {
                Universities = filteredUnis,
                Filter = model,
                UniversitiesCount = universitiesList.Count
            };

            return this.View(viewDataModel);
        }

        public ActionResult Details(int id)
        {
            var university = this.universities.GetById(id);
            var model = this.Mapper.Map<UniversityDetailsViewModel>(university);

            return this.View(model);
        }
    }
}