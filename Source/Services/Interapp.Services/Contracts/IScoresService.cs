namespace Interapp.Services.Contracts
{
    using Data.Models;

    public interface IScoresService
    {
        ScoreReport GetByStudentId(string studentId);

        void Create(ScoreReport scores);

        void Update(ScoreReport scores);

        void Delete(string studentId);
    }
}
