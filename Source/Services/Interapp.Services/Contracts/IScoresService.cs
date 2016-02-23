namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IScoresService
    {
        IQueryable<ScoreReport> All();

        ScoreReport GetByStudentId(string studentId);

        void Create(ScoreReport scores);

        void Update(ScoreReport scores);

        void Delete(string studentId);
    }
}
