namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Common;
    using Services.Contracts;
    using ViewModels.Universities;

    public class UniversitiesController : StudentController
    {
        private IUniversitiesService universities;
        private IStudentInfosService studentInfos;
        private IMajorsService majors;
        private IApplicationsService applications;

        public UniversitiesController(
            IUniversitiesService universities,
            IStudentInfosService studentInfos,
            IMajorsService majors,
            IApplicationsService applications)
        {
            this.universities = universities;
            this.studentInfos = studentInfos;
            this.majors = majors;
            this.applications = applications;
        }

        public ActionResult All(FilterModel model)
        {
            var studentId = this.User.Identity.GetUserId();

            var filteredUnis = this.universities
                .FilterUniversities(this.universities.AllForStudent(studentId), model)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int id)
        {
            if (this.Request.IsAjaxRequest())
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
            var hasApplied = this.applications
                .All()
                .Any(a => a.StudentId == studentId && a.UniversityId == id);

            var model = new DetailsInformationViewModel()
            {
                Eligibility = eligiblity,
                Student = this.Mapper.Map<StudentInfoApplicationViewModel>(student),
                University = this.Mapper.Map<UniversityDetailsViewModel>(university),
                HasApplied = hasApplied
            };

            return this.View(model);
        }

        public ActionResult ApplicationForm(int id)
        {
            var model = new ApplicationInputViewModel();
            var majorsList = this.Cache.Get("Majors", () => this.majors.All().ToList(), 60 * 60);
            model.Majors = new SelectList(majorsList, "Id", "Name", model.MajorId);
            model.UniversityId = id;

            return this.PartialView("_ApplicationForm", model);
        }
    }
}