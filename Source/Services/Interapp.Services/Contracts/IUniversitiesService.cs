namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;

    public interface IUniversitiesService
    {
        IQueryable<University> All();

        University GetById(int id);

        void Update(University university);

        void Delete(int id);

        void Create(string directorId, string name, int tuitionFee, int countryId);

        IQueryable<University> FilterUniversities(IQueryable<University> universities, FilterModel filter);

        IQueryable<University> AllWithDirectorAndCountry();

        IQueryable<University> AllWithCountry();

        IQueryable<University> AllForStudent(string studentId);

        University GetByIdWithDocuments(int id);
    }
}
