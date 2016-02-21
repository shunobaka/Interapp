namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using Common.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.StudentRoleName)]
    public class StudentController : BaseController
    {
    }
}