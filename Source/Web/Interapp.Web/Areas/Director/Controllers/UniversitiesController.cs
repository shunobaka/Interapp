namespace Interapp.Web.Areas.Director.Controllers
{
    using AutoMapper;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.UniversityViewModels;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    [Authorize(Roles = "Director")]
    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;
        private ICountriesService countries;

        public UniversitiesController(IUniversitiesService universities, ICountriesService countries)
        {
            this.universities = universities;
            this.countries = countries;
        }

        private IEnumerable<Country> GetCountries()
        {
            if (this.HttpContext.Cache["Countries"] == null)
            {
                this.HttpContext.Cache.Add("Countries",
                    this.countries.All().ToList(),
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default, null);
            }

            return (IEnumerable<Country>)this.HttpContext.Cache["Countries"];
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new UniversityCreateViewModel();
            model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(UniversityCreateViewModel model)
        {
            var universityWithNameExists = this.universities.All().Any(u => u.Name == model.Name);

            if (universityWithNameExists)
            {
                this.ModelState.AddModelError("Existing university", "There is already a university with this name.");
            }

            var countryExists = this.countries.All().Any(c => c.Id == model.CountryId);

            if (!countryExists)
            {
                this.ModelState.AddModelError("Nonexisting country", "No such country exists - if you are sure of what you're doing, contact administrator.");
            }

            if (this.ModelState.IsValid)
            {
                var directorId = this.User.Identity.GetUserId();
                this.universities.Create(directorId, model.Name, model.TuitionFee, model.CountryId);
                return this.RedirectToAction("Index", "Home", null);
            }

            model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var university = this.universities.GetById(id);
            var userId = this.User.Identity.GetUserId();

            if (university != null && university.DirectorId == userId)
            {
                var model = Mapper.Map<UniversityViewModel>(university);
                model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);

                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        public ActionResult Edit(int id, UniversityViewModel model)
        {
            var university = this.universities.GetById(id);
            var userId = this.User.Identity.GetUserId();

            if (university == null || university.DirectorId == userId)
            {
                this.ModelState.AddModelError("Edit", "Either there is no such university, or you don't have permissions to edit it.");
            }

            if (this.ModelState.IsValid)
            {
                //this.universities.Update();
                // TODO: Implement
            }

            return this.View(model);
        }
    }
}