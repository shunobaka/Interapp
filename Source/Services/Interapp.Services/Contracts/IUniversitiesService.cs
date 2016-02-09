namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;
    using Interapp.Common.Enums;

    public interface IUniversitiesService
    {
        IQueryable<University> All();

        IQueryable<University> GetFiltered(FilterModel filter);

        University GetById(int id);

        void Update(int universityId,
            int countryId,
            string name,
            CambridgeLevel? cambridgeLevel,
            CambridgeResult? cambridgeScore,
            int? ibtToefl,
            int? pbtToefl,
            int? sat,
            int tuition);

        void DeleteById(int id);

        void Create(string directorId, string name, int tuitionFee, int countryId);
    }
}
