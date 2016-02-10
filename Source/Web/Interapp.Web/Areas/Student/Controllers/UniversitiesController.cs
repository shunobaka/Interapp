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
    }
}