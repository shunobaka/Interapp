namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;
    using Models.ResponsesViewModels;
    using Services.Contracts;

    [Authorize(Roles = "Student")]
    public class ResponsesController : Controller
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
                .ProjectTo<ResponseViewModel>()
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

            var model = Mapper.Map<ResponseViewModel>(response);

            return this.View(model);
        }
    }
}