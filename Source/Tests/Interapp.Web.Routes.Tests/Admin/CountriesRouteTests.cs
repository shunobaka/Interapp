namespace Interapp.Web.Routes.Tests.Admin
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Admin;
    using Areas.Admin.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class CountriesRouteTests
    {
        [Test]
        public void TestRouteAdminCountriesIndex()
        {
            const string Url = "/Admin/Countries";
            const string AreaName = "Admin";

            var routeCollection = new RouteCollection();

            var areaRegistration = new AdminAreaRegistration();
            Assert.AreEqual(AreaName, areaRegistration.AreaName);
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            routeCollection.ShouldMap(Url).To<CountriesController>(c => c.Index());
        }
    }
}
