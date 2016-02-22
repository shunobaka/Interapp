namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Applications;

    public class ApplicationsController : AdminController
    {
        private IApplicationsService applications;
        private IMajorsService majors;

        public ApplicationsController(IApplicationsService applications, IMajorsService majors)
        {
            this.applications = applications;
            this.majors = majors;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult ApplicationsRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.applications.All().To<ApplicationViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationsUpdate([DataSourceRequest]DataSourceRequest request, ApplicationViewModel application)
        {
            ApplicationViewModel result = null;

            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Application>(application);
                this.applications.Update(entity);

                result = this.Mapper.Map<ApplicationViewModel>(this.applications.GetById(application.Id));
            }

            if (result != null)
            {
                return this.Json(new[] { result }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { application }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ApplicationsDestroy([DataSourceRequest]DataSourceRequest request, ApplicationViewModel application)
        {
            this.applications.Delete(application.Id);

            return this.Json(new[] { application }.ToDataSourceResult(request, this.ModelState));
        }

        [ChildActionOnly]
        public ActionResult GetDropdownList()
        {
            var majorsList = this.majors.All();
            var model = new SelectList(majorsList, "Id", "Name", "MajorId");

            return this.PartialView("_MajorsDropdown", model);
        }
    }
}