namespace Interapp.Services.Contracts
{
    using Data.Models;

    public interface IEssaysService
    {
        Essay GetByStudentId(string studentId);

        void Create(string studentId, string title, string content);

        void Update(string studentId, string title, string content);

        void Delete(string studentId);
    }
}
