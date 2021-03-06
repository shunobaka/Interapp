﻿namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Contracts;
    using ViewModels.Users;

    public class UsersController : AdminController
    {
        private IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult UsersRead([DataSourceRequest]DataSourceRequest request)
        {
            var model = this.users.All().To<UserViewModel>();
            DataSourceResult result = model.ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsersUpdate([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<User>(user);
                this.users.Update(entity);
            }

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UsersDestroy([DataSourceRequest]DataSourceRequest request, UserViewModel user)
        {
            this.users.Delete(user.Id);

            return this.Json(new[] { user }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
