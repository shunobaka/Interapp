namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Data.Models;
    using Services.Contracts;
    using AutoMapper.QueryableExtensions;
    using Models.UsersViewModels;

    public class UsersController : Controller
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.users.All().ProjectTo<UserViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, User user)
        {
            if (ModelState.IsValid)
            {
                var entity = new User
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Email = user.Email
                };

                this.users.Update(user);
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, User user)
        {
            this.users.Delete(user.Id);

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }
    }
}
