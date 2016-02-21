namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.UniversitiesViewModels;
    using Services.Common;
    using Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    [Authorize(Roles = "Student")]
    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;
        private IStudentInfosService studentInfos;
        private IMajorsService majors;

        public UniversitiesController(IUniversitiesService universities, IStudentInfosService studentInfos, IMajorsService majors)
        {
            this.universities = universities;
            this.studentInfos = studentInfos;
            this.majors = majors;
        }

        public ActionResult All(FilterModel model)
        {
            var studentId = this.User.Identity.GetUserId();
            var viewModelUnis = this.universities
                .FilterUniversities(this.universities.AllForStudent(studentId), model)
                .ProjectTo<UniversitySimpleViewModel>()
                .ToList();

            var viewModel = new UniversitiesListViewModel()
            {
                Universities = viewModelUnis,
                UniversitiesCount = viewModelUnis.Count,
                Filter = model
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(int id)
        {
            if (Request.IsAjaxRequest())
            {
                var studentId = this.User.Identity.GetUserId();
                var universitiesOfInterest = this.studentInfos.GetUniversitiesOfInterest(studentId);

                if (!universitiesOfInterest.Any(u => u.Id == id))
                {
                    this.studentInfos.AddUniversityOfInterest(studentId, id);
                    return this.PartialView("_SuccessfullyAdded");
                }

                return this.PartialView("_AlreadyAdded");
            }

            return this.PartialView("_NotAjaxError");
        }

        public ActionResult Details(int id)
        {
            var studentId = this.User.Identity.GetUserId();
            var university = this.universities.GetByIdWithDocuments(id);
            var student = this.studentInfos.GetByIdWithDocumentsAndScores(studentId);
            var eligiblity = this.studentInfos.IsEligibleToApply(student, university);

            var model = new DetailsInformationViewModel()
            {
                Eligibility = eligiblity,
                Student = Mapper.Map<StudentInfoApplicationViewModel>(student),
                University = Mapper.Map<UniversityDetailsViewModel>(university)
            };

            return this.View(model);
        }
        
        public ActionResult ApplicationForm(int id)
        {
            var model = new ApplicationInputViewModel();
            model.Majors = new SelectList(this.GetMajors(), "Id", "Name", model.MajorId);
            model.UniversityId = id;

            return this.PartialView("_ApplicationForm", model);
        }

        private IEnumerable<Major> GetMajors()
        {
            if (this.HttpContext.Cache["Majors"] == null)
            {
                this.HttpContext.Cache.Add(
                    "Majors",
                    this.majors.All().ToList(),
                    null,
                    DateTime.Now.AddHours(1),
                    TimeSpan.Zero,
                    CacheItemPriority.Default,
                    null);
            }

            return (IEnumerable<Major>)this.HttpContext.Cache["Majors"];
        }
    }
}