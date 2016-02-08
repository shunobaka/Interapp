namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;

    public interface IUniversitiesService
    {
        IQueryable<University> All();

        IQueryable<University> GetFiltered(FilterModel filter);

        University GetById(int id);

        void UpdateById(int id, University university);

        void DeleteById(int id);

        void Create(string directorId, string name, int tuitionFee, int countryId);

        IQueryable<University> GetForUserWithDocuments(string studentId);
    }
}
