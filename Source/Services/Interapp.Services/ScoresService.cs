namespace Interapp.Services
{
    using System.Linq;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class ScoresService : IScoresService
    {
        private IRepository<ScoreReport> scores;

        public ScoresService(IRepository<ScoreReport> scores)
        {
            this.scores = scores;
        }

        public void Create(ScoreReport newScores)
        {
            this.scores.Add(newScores);
            this.scores.SaveChanges();
        }

        public void Delete(string studentId)
        {
            this.scores.Delete(studentId);
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

            this.scores.SaveChanges();
        }
    }
}
