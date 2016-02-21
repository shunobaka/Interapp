namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models.ResponsesViewModels;
    using Services.Contracts;

    public class ResponsesController : StudentController
    {
        private IResponsesService responses;

        public ResponsesController(IResponsesService responses)
        {
            this.responses = responses;
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
    }
}