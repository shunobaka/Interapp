namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Data.Models;

    public interface IEssaysService
    {
        IQueryable<Essay> All();

        Essay GetByStudentId(string studentId);

        void Create(string studentId, string title, string content);

        void Update(Essay essay);

        void Delete(string studentId);
    }
}
