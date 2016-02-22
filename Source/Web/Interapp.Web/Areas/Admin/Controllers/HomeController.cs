namespace Interapp.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class HomeController : AdminController
    {
        public ActionResult Index()
        {
            var panels = new List<string>()
            {
                "Applications",
                "Countries",
                "Documents",
                "Essays",
                "Majors",
                "Responses",
                "Scores",
                "Universities",
                "Users"
            };

            return this.View(panels);
        }
    }
}