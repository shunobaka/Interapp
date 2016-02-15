namespace Interapp.Web.Areas.Student.Controllers
{
    using AutoMapper;
    using Models.EssayViewModels;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System.Web.Mvc;

    [Authorize(Roles = "Student")]
    public class EssayController : Controller
    {
        private IEssaysService essays;

        public EssayController(IEssaysService essays)
        {
            this.essays = essays;
        }

        public ActionResult Review()
        {
            var studentId = this.User.Identity.GetUserId();
            var essay = this.essays
                .GetByStudentId(studentId);

            var model = Mapper.Map<EssayViewModel>(essay);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var studentId = this.User.Identity.GetUserId();
            var essay = this.essays
               .GetByStudentId(studentId);

            var model = Mapper.Map<EssayViewModel>(essay);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EssayViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                this.essays.Update(studentId, model.Title, model.Content);

                return this.RedirectToAction(nameof(this.Review));
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            var model = new DeleteInfoViewModel()
            {
                ControllerName = "Essay",
                ItemName = "essay"
            };
            return this.View(model);
        }
        
        public ActionResult Deleted()
        {
            var model = new DeleteInfoViewModel()
            {
                ControllerName = "Essay",
                ItemName = "essay"
            };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult DeletePost()
        {
            var studentId = this.User.Identity.GetUserId();
            this.essays.Delete(studentId);

            return this.RedirectToAction(nameof(this.Deleted));
        }
    }
}