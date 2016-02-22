namespace Interapp.Web.Routes.Tests.Student
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Student;
    using Areas.Student.Controllers;
    using Areas.Student.ViewModels.Essay;
    using MvcRouteTester;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class EssayRouteTests
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
        public void TestRouteStudentEssayReview()
        {
            const string Url = "/Student/Essay/Review";
            this.RouteCollection
                .ShouldMap(Url)
                .To<EssayController>(c => c.Review());
        }

        [Test]
        public void TestRouteStudentEssayEditGet()
        {
            const string Url = "/Student/Essay/Edit";
            this.RouteCollection
                .ShouldMap(Url)
                .To<EssayController>(c => c.Edit());
        }

        [Test]
        public void TestRouteStudentEssayEditPost()
        {
            const string Url = "/Student/Essay/Edit";

            var model = new EssayViewModel()
            {
                Content = "Something",
                Title = "Test"
            };
            var jsonBody = JsonConvert.SerializeObject(model);

            this.RouteCollection
                .ShouldMap(Url)
                .WithJsonBody(jsonBody)
                .To<EssayController>(c => c.Edit());
        }
    }
}
