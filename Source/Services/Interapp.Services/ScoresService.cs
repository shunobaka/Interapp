namespace Interapp.Services
{
    using Contracts;
    using System.Linq;
    using Data.Models;
    using System;
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
            this.scores.Update(newScores);
            this.scores.SaveChanges();
        }
    }
}
