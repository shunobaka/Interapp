﻿namespace Interapp.Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult ServerError()
        {
            return this.View();
        }
    }
}