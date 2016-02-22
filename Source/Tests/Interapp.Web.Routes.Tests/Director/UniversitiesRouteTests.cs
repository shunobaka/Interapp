namespace Interapp.Web.Routes.Tests.Director
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Director;
    using Areas.Director.Controllers;
    using Areas.Director.ViewModels.Universities;
    using MvcRouteTester;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class UniversitiesRouteTests
    {
        public RouteCollection RouteCollection { get; private set; }

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
        public void TestRouteDirectorUniversitiesAddGet()
        {
            const string Url = "/Director/Universities/Edit/5";
            this.RouteCollection
                .ShouldMap(Url)
                .To<UniversitiesController>(c => c.Edit(5));
        }

        [Test]
        public void TestRouteDirectorUniversitiesAddPost()
        {
            const string Url = "/Director/Universities/Add";

            var model = new UniversityCreateViewModel()
            {
                Name = "Something",
                TuitionFee = 500
            };
            var jsonBody = JsonConvert.SerializeObject(model);

            this.RouteCollection
                .ShouldMap(Url)
                .WithJsonBody(jsonBody)
                .To<UniversitiesController>(c => c.Add(model));
        }

        [Test]
        public void TestRouteDirectorUniversitiesEdit()
        {
            const string Url = "/Director/Universities/Edit/5";
            this.RouteCollection
                .ShouldMap(Url)
                .To<UniversitiesController>(c => c.Edit(5));
        }
    }
}
