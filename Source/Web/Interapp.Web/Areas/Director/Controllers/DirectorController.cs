namespace Interapp.Web.Areas.Director.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.DirectorRoleName)]
    public class DirectorController : BaseController
    {
    }
}