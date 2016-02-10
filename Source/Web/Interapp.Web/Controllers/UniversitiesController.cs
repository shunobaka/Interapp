namespace Interapp.Web.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Interapp.Services.Common;
    using Interapp.Services.Contracts;
    using Models.Shared;
    using Models.UniversityViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    [Authorize]
    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }

        private IList<University> GetUniversities()
        {
            if (this.HttpContext.Cache["Universities"] == null)
            {
                var unis = this.universities.AllSimple().ToList();
                this.HttpContext.Cache.Add("Universities",
                    unis,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default, null);
            }

            return (IList<University>)this.HttpContext.Cache["Universities"];
        }
        
        public ActionResult All(FilterModel model)
        {
            var unis = GetUniversities();

            var filteredUnis = this.universities
                .FilterUniversities(unis.AsQueryable(), model)
                .ProjectTo<UniversitySimpleViewModel>()
                .ToList();

            var viewDataModel = new AllUniversitiesViewModel()
            {
                Universities = filteredUnis,
                Filter = model,
                UniversitiesCount = unis.Count
            };

            return View(viewDataModel);
        }

        public ActionResult Details(int id)
        {
            var university = this.universities.GetById(id);
            var model = Mapper.Map<UniversityViewModel>(university);

            return this.View(model);
        }
    }
}