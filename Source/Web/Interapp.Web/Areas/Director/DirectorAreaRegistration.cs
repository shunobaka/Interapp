using System.Web.Mvc;

namespace Interapp.Web.Areas.Director
{
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
                "Director_default",
                "Director/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Director.Controllers" }
            )
            .DataTokens["UseNamespaceFallback"] = true;
        }
    }
}