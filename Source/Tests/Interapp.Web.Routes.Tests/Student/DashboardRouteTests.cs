namespace Interapp.Web.Routes.Tests.Student
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Student;
    using Areas.Student.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class DashboardRouteTests
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
        public void TestRouteStudentDashboardInfo()
        {
            const string Url = "/Student";
            this.RouteCollection
                .ShouldMap(Url)
                .To<DashboardController>(c => c.Info());
        }
    }
}
