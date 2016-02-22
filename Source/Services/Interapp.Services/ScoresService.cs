namespace Interapp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class ScoresService : IScoresService
    {
        private IDbRepository<ScoreReport> scores;

        public ScoresService(IDbRepository<ScoreReport> scores)
        {
            this.scores = scores;
        }

        public IQueryable<ScoreReport> All()
        {
            return this.scores.All();
        }

        public void Create(ScoreReport newScores)
        {
            this.scores.Add(newScores);
            this.scores.Save();
        }

        public void Delete(string studentId)
        {
            var score = this.scores.GetById(studentId);
            this.scores.Delete(score);
            this.scores.Save();
        }

        public ScoreReport GetByStudentId(string studentId)
        {
            var scoresForStudent = this.scores
                .All()
                .Where(s => s.StudentInfoId == studentId)
                .FirstOrDefault();

            return scoresForStudent;
        }

        public void Update(ScoreReport newScores)
        {
            var scoreReport = this.scores
                .All()
                .Where(e => e.StudentInfoId == newScores.StudentInfoId)
                .FirstOrDefault();

            if (scoreReport == null)
            {
                this.Create(newScores);
                return;
            }

            scoreReport.SatCRResult = newScores.SatCRResult;
            scoreReport.SatMathResult = newScores.SatMathResult;
            scoreReport.SatWritingResult = newScores.SatWritingResult;
            scoreReport.ToeflType = newScores.ToeflType;
            scoreReport.ToeflResult = newScores.ToeflResult;
            scoreReport.CambridgeLevel = newScores.CambridgeLevel;
            scoreReport.CambridgeResult = newScores.CambridgeResult;

            this.scores.Save();
        }
    }
}
