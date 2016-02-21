namespace Interapp.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Models.UniversitiesViewModels;
    using Services.Common;
    using Services.Contracts;

    [Authorize]
    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        public ActionResult All(FilterModel model)
        {
            var unis = this.GetUniversities();

            var filteredUnis = this.universities
                .FilterUniversities(unis.AsQueryable(), model)
                .ProjectTo<UniversitySimpleViewModel>()
                .ToList();

            var viewDataModel = new UniversitiesListViewModel()
            {
                Universities = filteredUnis,
                Filter = model,
                UniversitiesCount = unis.Count
            };

            return this.View(viewDataModel);
        }

        public ActionResult Details(int id)
        {
            var university = this.universities.GetById(id);
            var model = Mapper.Map<UniversityDetailsViewModel>(university);

            return this.View(model);
        }

        private IList<University> GetUniversities()
        {
            if (this.HttpContext.Cache["Universities"] == null)
            {
                // TODO: Make cache for hour
                var unis = this.universities.AllWithCountry().ToList();
                this.HttpContext.Cache.Add(
                    "Universities",
                    unis,
                    null,
                    DateTime.Now.AddSeconds(10),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return (IList<University>)this.HttpContext.Cache["Universities"];
        }
    }
}