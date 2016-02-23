namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Students;

    public class StudentsController : AdminController
    {
        private IStudentInfosService students;
        private IUniversitiesService universities;
        private IMajorsService majors;

        public StudentsController(IStudentInfosService students, IUniversitiesService universities, IMajorsService majors)
        {
            this.students = students;
            this.universities = universities;
            this.majors = majors;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult StudentsRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.students.All().To<StudentViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult StudentsUpdate([DataSourceRequest]DataSourceRequest request, StudentViewModel student)
        {
            StudentViewModel result = null;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<StudentInfo>(student);
                this.students.Update(entity);

                result = this.Mapper.Map<StudentViewModel>(this.students.GetById(entity.StudentId));
            }

            if (result != null)
            {
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { student }.ToDataSourceResult(request, this.ModelState));
        }

        [ChildActionOnly]
        public ActionResult GetUniversitiesDropdownList()
        {
            var universitiesList = this.universities.All().To<UniversityViewModel>();
            var model = new SelectList(universitiesList, "Id", "Name", "UniversityId");

            return this.PartialView("_UniversitiesDropdown", model);
        }

        [ChildActionOnly]
        public ActionResult GetMajorsDropdownList()
        {
            var majorsList = this.Cache.Get("AdminMajors", () => this.majors.All(), 60 * 5);
            var model = new SelectList(majorsList, "Id", "Name", "MajorId");

            return this.PartialView("_MajorsDropdown", model);
        }
    }
}