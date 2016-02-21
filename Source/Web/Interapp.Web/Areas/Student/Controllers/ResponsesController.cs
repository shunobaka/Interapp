namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Models.ResponsesViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;
    using AutoMapper;
    using System.Linq;

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

            return View(model);
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