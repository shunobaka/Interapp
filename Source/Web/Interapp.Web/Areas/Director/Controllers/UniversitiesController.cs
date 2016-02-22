namespace Interapp.Web.Areas.Director.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Universities;

    public class UniversitiesController : DirectorController
    {
        private IUniversitiesService universities;
        private ICountriesService countries;

        public UniversitiesController(IUniversitiesService universities, ICountriesService countries)
        {
            this.universities = universities;
            this.countries = countries;
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new UniversityCreateViewModel();
            model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                var model = this.Mapper.Map<UniversityViewModel>(university);
                model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);

                return this.View(model);
            }

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UniversityViewModel model)
        {
            var cachedCountries = this.GetCountries();

            var countryExists = cachedCountries.Any(c => c.Id == model.CountryId);

            if (!countryExists)
            {
                this.ModelState.AddModelError("Nonexisting country", "No such country exists.");
            }

            var university = this.universities.GetById(id);
            var userId = this.User.Identity.GetUserId();

            if (university == null || university.DirectorId != userId)
            {
                this.ModelState.AddModelError("Edit", "Either there is no such university, or you don't have permissions to edit it.");
            }

            if (this.ModelState.IsValid)
            {
                var universityUpdateModel = new University()
                {
                    Id = id,
                    CountryId = model.CountryId,
                    Name = model.Name,
                    RequiredCambridgeLevel = model.RequiredCambridgeLevel,
                    RequiredCambridgeScore = model.RequiredCambridgeScore,
                    RequiredIBTToefl = model.RequiredIBTToefl,
                    RequiredPBTToefl = model.RequiredPBTToefl,
                    RequiredSAT = model.RequiredSAT,
                    TuitionFee = model.TuitionFee
                };
                this.universities.Update(universityUpdateModel);
                return this.RedirectToRoute("/Director");
            }

            model.Countries = new SelectList(this.GetCountries(), "Id", "Name", model.CountryId);
            return this.View(model);
        }

        [ChildActionOnly]
        public ActionResult GetDropdownList()
        {
            var directorId = this.User.Identity.GetUserId();
            var modelUniversities = this.universities.All()
                .Where(u => u.DirectorId == directorId);

            var model = new SelectList(modelUniversities, "Id", "Name", "UniversityId");
            return this.PartialView("_UniversitiesDropdown", model);
        }

        private IEnumerable<Country> GetCountries()
        {
            if (this.HttpContext.Cache["Countries"] == null)
            {
                this.HttpContext.Cache.Add(
                    "Countries",
                    this.countries.All().ToList(),
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return (IEnumerable<Country>)this.HttpContext.Cache["Countries"];
        }
    }
}