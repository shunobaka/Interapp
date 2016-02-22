using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interapp.Web.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Admin/Students
        public ActionResult Index()
        {
            return View();
        }
    }
}