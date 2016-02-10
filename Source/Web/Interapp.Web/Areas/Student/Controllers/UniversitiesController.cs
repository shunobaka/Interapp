namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Services.Common;
    using Services.Contracts;
    using Web.Models.Shared;
    using Web.Models.UniversityViewModels;
    using Microsoft.AspNet.Identity;

    [Authorize(Roles = "Student")]
    public class UniversitiesController : Controller
    {
        private IUniversitiesService universities;
        private IStudentInfosService studentInfos;

        public UniversitiesController(IUniversitiesService universities, IStudentInfosService studentInfos)
        {
            this.universities = universities;
            this.studentInfos = studentInfos;
        }

        public ActionResult All(FilterModel model)
        {
            var studentId = this.User.Identity.GetUserId();
            var viewModelUnis = this.universities
                .FilterUniversities(this.studentInfos.GetUniversitiesOfInterest(studentId), model)
                .ProjectTo<UniversitySimpleViewModel>()
                .ToList();

            var viewModel = new AllUniversitiesViewModel()
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
    }
}