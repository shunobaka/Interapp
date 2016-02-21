namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Common;
    using Data.Models;

    public class CountriesService : ICountriesService
    {
        private IDbRepository<Country> countries;

        public CountriesService(IDbRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries
                .All()
                .OrderBy(c => c.Name);
        }

        public void Create(string name)
        {
            var country = new Country()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow
            };

            this.countries.Add(country);
            this.countries.Save();
        }

        public void DeleteById(int id)
        {
            var country = this.countries.GetById(id);
            this.countries.Delete(country);
            this.countries.Save();
        }

        public Country GetById(int id)
        {
            return this.countries
                .All()
                .Where(c => c.Id == id)
                .FirstOrDefault();
        }

        public IQueryable<Country> GetFiltered(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int id, Country country)
        {
            throw new NotImplementedException();
        }
    }
}
