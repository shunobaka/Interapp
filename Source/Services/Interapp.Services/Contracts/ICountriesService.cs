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

        void Update(Country country);

        void Delete(int id);

        Country Create(string name);
    }
}
