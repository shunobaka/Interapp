namespace Interapp.Web.Routes.Tests.Student
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Student;
    using Areas.Student.Controllers;
    using Areas.Student.ViewModels.Applications;
    using MvcRouteTester;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class ApplicationsRouteTests
    {
        public RouteCollection RouteCollection { get; private set; }

        [TestFixtureSetUp]
        public void Initialize()
        {
            const string AreaName = "Student";
            this.RouteCollection = new RouteCollection();
            var areaRegistration = new StudentAreaRegistration();
            Assert.AreEqual(AreaName, areaRegistration.AreaName);
            var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, this.RouteCollection);
            areaRegistration.RegisterArea(areaRegistrationContext);
        }

        [Test]
        public void TestRouteStudentApplicationsAll()
        {
            const string Url = "/Student/Applications/All";
            this.RouteCollection
                .ShouldMap(Url)
                .To<ApplicationsController>(c => c.All());
        }

        [Test]
        public void TestRouteStudentApplicationsDetails()
        {
            const string Url = "/Student/Applications/Details/5";
            this.RouteCollection
                .ShouldMap(Url)
                .To<ApplicationsController>(c => c.Details(5));
        }

        [Test]
        public void TestRouteStudentApplicationsSubmit()
        {
            const string Url = "/Student/Applications/Submit";

            var model = new ApplicationInputViewModel()
            {
                MajorId = 1,
                UniversityId = 1
            };
            var jsonBody = JsonConvert.SerializeObject(model);

            this.RouteCollection
                .ShouldMap(Url)
                .WithJsonBody(jsonBody)
                .To<ApplicationsController>(c => c.Submit(model));
        }
    }
}
