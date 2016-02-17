namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;

    public interface IApplicationsService
    {
        IQueryable<Application> All();

        IQueryable<Application> AllByUniversity(int universityId);

        IQueryable<Application> AllByStudent(string studentId);

        IQueryable<Application> AllByDirector(string directorId);

        IQueryable<Application> GetFilteredByUniversity(int universityId, FilterModel filter);

        Application GetById(int id);

        void Delete(int id);

        void Create(string studentId, int universityId, int majorId);
    }
}
