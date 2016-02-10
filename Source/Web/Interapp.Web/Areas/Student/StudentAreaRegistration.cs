namespace Interapp.Web.Areas.Student
{
    using System.Web.Mvc;

    public class StudentAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Student_default",
                url: "Student/{controller}/{action}/{id}",
                defaults: new { controller = "Dashboard", action = "Info", id = UrlParameter.Optional },
                namespaces: new string[] { "Interapp.Web.Areas.Student.Controllers" }
            )
            .DataTokens["UseNamespaceFallback"] = false;
        }
    }
}