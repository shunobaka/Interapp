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

    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;

        public UniversitiesController(IUniversitiesService universities)
        {
            this.universities = universities;
        }
        
        public ActionResult All(FilterModel model)
        {
            if (this.HttpContext.Cache["Universities"] == null)
            {
                var unis = this.universities.AllSimple().ToList();
                this.HttpContext.Cache.Add("UniversitiesCount",
                    unis.Count,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default, null);
                this.HttpContext.Cache.Add("Universities",
                    unis,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default, null);
            }

            var filteredUnis = this.universities
                .FilterUniversities(((IList<University>)this.HttpContext.Cache["Universities"]).AsQueryable(), model)
                .ProjectTo<UniversitySimpleViewModel>()
                .ToList();

            var viewDataModel = new AllUniversitiesViewModel()
            {
                Universities = filteredUnis,
                Filter = model,
                UniversitiesCount = (int)this.HttpContext.Cache["UniversitiesCount"]
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