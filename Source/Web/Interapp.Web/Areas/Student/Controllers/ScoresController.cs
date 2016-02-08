﻿namespace Interapp.Web.Areas.Student.Controllers
{
    using Services.Contracts;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Models.ScoresViewModels;
    using Microsoft.AspNet.Identity;
    using Models.Shared;

    public class ScoresController : Controller
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

            var model = Mapper.Map<ScoresViewModel>(score);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var studentId = this.User.Identity.GetUserId();
            var score = this.scores
               .GetByStudentId(studentId);

            var model = Mapper.Map<ScoresViewModel>(score);

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ScoresViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = this.User.Identity.GetUserId();
                var scoresReport = new ScoreReport()
                {
                    CambridgeLevel = model.CambridgeLevel,
                    CambridgeResult = model.CambridgeResult,
                    SatCRResult = model.SatCRResult,
                    SatMathResult = model.SatMathResult,
                    SatWritingResult = model.SatWritingResult,
                    ToeflResult = model.ToeflResult,
                    ToeflType = model.ToeflType,
                    StudentInfoId = studentId
                };
                this.scores.Update(scoresReport);

                return this.RedirectToAction(nameof(this.Review));
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Delete()
        {
            var model = new DeleteInfoViewModel()
            {
                ItemName = "scores",
                ControllerName = "Scores"
            };
            return this.View(model);
        }

        public ActionResult Deleted()
        {
            var model = new DeleteInfoViewModel()
            {
                ItemName = "scores",
                ControllerName = "Scores"
            };
            return this.View(model);
        }

        [HttpPost]
        public ActionResult DeletePost()
        {
            var studentId = this.User.Identity.GetUserId();
            this.scores.Delete(studentId);

            return this.RedirectToAction(nameof(this.Deleted));
        }
    }
}