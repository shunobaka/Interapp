namespace Interapp.Web.Areas.Student.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using ViewModels.Scores;

    public class ScoresController : StudentController
    {
        private IScoresService scores;

        public ScoresController(IScoresService scores)
        {
            this.scores = scores;
        }

        public ActionResult Review()
        {
            var studentId = this.User.Identity.GetUserId();
            var score = this.scores
                .GetByStudentId(studentId);

            var model = this.Mapper.Map<ScoresViewModel>(score);
            return this.View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var studentId = this.User.Identity.GetUserId();
            var score = this.scores
               .GetByStudentId(studentId);

            var model = this.Mapper.Map<ScoresViewModel>(score);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoresViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                var scoresReport = this.Mapper.Map<ScoreReport>(model);
                scoresReport.StudentInfoId = studentId;
                this.scores.Update(scoresReport);

                return this.RedirectToAction(nameof(this.Review));
            }

            return this.View(model);
        }
    }
}