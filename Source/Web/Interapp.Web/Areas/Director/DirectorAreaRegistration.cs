namespace Interapp.Web.Areas.Director
{
    using System.Web.Mvc;

    public class DirectorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Director";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Director_default",
                url: "Director/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Interapp.Web.Areas.Director.Controllers" })
            .DataTokens["UseNamespaceFallback"] = false;
        }
    }
}