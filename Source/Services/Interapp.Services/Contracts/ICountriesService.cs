namespace Interapp.Services.Contracts
{
    using System.Linq;
    using Common;
    using Data.Models;

    public interface ICountriesService
    {
        IQueryable<Country> All();

        IQueryable<Country> GetFiltered(FilterModel filter);

        Country GetById(int id);

        void UpdateById(int id, Country country);

        void DeleteById(int id);

        void Create(string name);
    }
}
