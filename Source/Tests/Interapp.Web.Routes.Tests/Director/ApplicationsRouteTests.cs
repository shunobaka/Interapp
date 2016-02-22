namespace Interapp.Web.Routes.Tests.Director
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Director;
    using Areas.Director.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class ApplicationsRouteTests
    {
        private RouteCollection RouteCollection { get; set; }

        [TestFixtureSetUp]
        public void Initialize()
        {
            const string AreaName = "Director";
            this.RouteCollection = new RouteCollection();
            var areaRegistration = new DirectorAreaRegistration();
            Assert.AreEqual(AreaName, areaRegistration.AreaName);
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, this.RouteCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);
        }

        [Test]
        public void TestRouteDirectorApplicationsAll()
        {
            const string Url = "/Director/Applications/All";
            this.RouteCollection.ShouldMap(Url).To<ApplicationsController>(c => c.All());
        }

        [Test]
        public void TestRouteDirectorApplicationsDetails()
        {
            const string Url = "/Director/Applications/Details/5";
            this.RouteCollection.ShouldMap(Url).To<ApplicationsController>(c => c.Details(5));
        }

        [Test]
        public void TestRouteDirectorApplicationsEvaluate()
        {
            const string Url = "/Director/Applications/Evaluate/5";
            this.RouteCollection.ShouldMap(Url).To<ApplicationsController>(c => c.Evaluate(5));
        }
    }
}
