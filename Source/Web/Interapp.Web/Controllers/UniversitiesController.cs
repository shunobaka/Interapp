namespace Interapp.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Interapp.Services.Common;
    using Interapp.Services.Contracts;
    using Models.UniversityViewModels;
    using System;
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

        public ActionResult All(FilterModel filter)
        {
            if (this.HttpContext.Cache["Universities"] == null)
            {
                var unis = this.universities.All();
                this.HttpContext.Cache.Add("Countries",
                    unis,
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default, null);
            }

            var model = this.universities
                .FilterUniversities((IQueryable<University>)this.HttpContext.Cache["Universities"], filter)
                .ProjectTo<UniversityViewModel>();

            return View(model);
        }
    }
}