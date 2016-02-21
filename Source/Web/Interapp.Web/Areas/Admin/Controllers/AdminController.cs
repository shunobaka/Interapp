namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRoleName)]
    public class AdminController : BaseController
    {
    }
}