namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Responses;

    public class ResponsesController : StudentController
    {
        private IResponsesService responses;
        private IStudentInfosService students;

        public ResponsesController(IResponsesService responses, IStudentInfosService students)
        {
            this.responses = responses;
            this.students = students;
        }

        public ActionResult All()
        {
            var studentId = this.User.Identity.GetUserId();
            var model = this.responses
                .GetByStudent(studentId)
                .To<ResponseViewModel>()
                .ToList();

            return this.View(model);
        }

        public ActionResult Details(int id)
        {
            var studentId = this.User.Identity.GetUserId();
            var response = this.responses.GetById(id);

            if (response == null || response.Application.StudentId != studentId)
            {
                return this.View();
            }

            var model = this.Mapper.Map<ResponseViewModel>(response);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Enroll(int id)
        {
            var response = this.responses.GetById(id);
            var application = response.Application;
            var studentId = this.User.Identity.GetUserId();

            if (response != null && application.StudentId == studentId && response.IsAdmitted)
            {
                this.students.EnrollStudent(studentId, application.UniversityId, application.MajorId);

                return this.PartialView("_Congratulations", application.University.Name);
            }

            return this.PartialView("_Sorry");
        }
    }
}