using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Interapp.Web.Startup))]
namespace Interapp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
