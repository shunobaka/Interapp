namespace Interapp.Web.Routes.Tests.Director
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Director;
    using Areas.Director.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class HomeRouteTests
    {
        [Test]
        public void TestRouteDirectorHomeIndex()
        {
            const string Url = "/Director/Home/Index?page=2";
            const string AreaName = "Director";

            var routeCollection = new RouteCollection();

            var areaRegistration = new DirectorAreaRegistration();
            Assert.AreEqual(AreaName, areaRegistration.AreaName);
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routeCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);

            routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index(2));
        }
    }
}
