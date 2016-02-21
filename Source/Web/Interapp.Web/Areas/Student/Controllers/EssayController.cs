namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Essay;

    public class EssayController : StudentController
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

            var model = this.Mapper.Map<EssayViewModel>(essay);

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var studentId = this.User.Identity.GetUserId();
            var essay = this.essays
               .GetByStudentId(studentId);

            var model = this.Mapper.Map<EssayViewModel>(essay);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EssayViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                var updateModel = new Essay()
                {
                    AuthorId = studentId,
                    Title = model.Title,
                    Content = model.Content
                };
                this.essays.Update(updateModel);

                return this.RedirectToAction(nameof(this.Review));
            }

            return this.View(model);
        }
    }
}