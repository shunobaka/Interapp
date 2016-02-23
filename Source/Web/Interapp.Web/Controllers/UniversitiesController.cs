namespace Interapp.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Common;
    using Services.Contracts;
    using ViewModels.Universities;
    
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
                .To<UniversitySimpleViewModel>();

            var universitiesCount = filteredUnis.Count();

            var page = 1;
            var pageSize = 10;

            if (model != null)
            {
                page = model.Page < 1 ? 1 : model.Page;
                pageSize = model.PageSize < 1 ? 1 : model.PageSize;
            }

            var resultUniversitiesList =
                filteredUnis
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

            var query = string.Empty;

            if (model != null)
            {
                query = "&Filter=" + model.Filter + "&OrderBy=" + model.OrderBy + "&Order=" + model.Order;
            }

            var viewDataModel = new UniversitiesListViewModel()
            {
                Universities = resultUniversitiesList,
                Filter = model,
                UniversitiesCount = universitiesCount,
                Query = query,
                Page = model.Page
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