namespace Interapp.Web.Routes.Tests.Student
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Student;
    using Areas.Student.Controllers;
    using Areas.Student.ViewModels.Documents;
    using MvcRouteTester;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class DocumentsRouteTests
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
        public void TestRouteStudentDocumentsAll()
        {
            const string Url = "/Student/Documents/All";
            this.RouteCollection
                .ShouldMap(Url)
                .To<DocumentsController>(c => c.All());
        }

        [Test]
        public void TestRouteStudentDocumentsCreateGet()
        {
            const string Url = "/Student/Documents/Create";
            this.RouteCollection
                .ShouldMap(Url)
                .To<DocumentsController>(c => c.Create());
        }

        [Test]
        public void TestRouteStudentDocumentsCreatePost()
        {
            const string Url = "/Student/Documents/Create";

            var model = new DocumentViewModel()
            {
                Content = "dasdas",
                Name = "dasdas",
                UniversityId = 5
            };
            var jsonBody = JsonConvert.SerializeObject(model);

            this.RouteCollection
                .ShouldMap(Url)
                .WithJsonBody(jsonBody)
                .To<DocumentsController>(c => c.Create());
        }

        [Test]
        public void TestRouteStudentDocumentsDetails()
        {
            const string Url = "/Student/Documents/Details/5";

            var model = new DocumentViewModel()
            {
                Content = "dasdas",
                Name = "dasdas",
                UniversityId = 5
            };
            var jsonBody = JsonConvert.SerializeObject(model);

            this.RouteCollection
                .ShouldMap(Url)
                .To<DocumentsController>(c => c.Details(5));
        }

        [Test]
        public void TestRouteStudentDocumentsEditPost()
        {
            const string Url = "/Student/Documents/Edit/5";
            this.RouteCollection
                .ShouldMap(Url)
                .To<DocumentsController>(c => c.Edit(5));
        }
    }
}
