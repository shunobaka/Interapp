namespace Interapp.Web.Routes.Tests.Director
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Director;
    using Areas.Director.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class DocumentsRouteTests
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
        public void TestRouteDirectorDocumentsAll()
        {
            const string Url = "/Director/Documents";
            this.RouteCollection.ShouldMap(Url).To<DocumentsController>(c => c.Index());
        }

        [Test]
        public void TestRouteDirectorDocumentsAdd()
        {
            const string Url = "/Director/Documents/Add";
            this.RouteCollection.ShouldMap(Url).To<DocumentsController>(c => c.Add());
        }
    }
}
