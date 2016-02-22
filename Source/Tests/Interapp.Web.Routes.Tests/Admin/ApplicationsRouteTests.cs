namespace Interapp.Web.Routes.Tests.Admin
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Admin;
    using Areas.Admin.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class ApplicationsRouteTests
    {
        [Test]
        public void TestRouteAdminApplicationsIndex()
        {
            const string Url = "/Admin/Applications";
            const string AreaName = "Admin";

            var routeCollection = new RouteCollection();

            var areaRegistration = new AdminAreaRegistration();
            Assert.AreEqual(AreaName, areaRegistration.AreaName);
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            routeCollection.ShouldMap(Url).To<ApplicationsController>(c => c.Index());
        }
    }
}
