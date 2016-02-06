namespace Interapp.Services
{
    using System;
    using System.Linq;
    using Common;
    using Contracts;
    using Data.Models;
    using Data.Repositories;

    public class CountriesService : ICountriesService
    {
        private IRepository<Country> countries;

        public CountriesService(IRepository<Country> countries)
        {
            this.countries = countries;
        }

        public IQueryable<Country> All()
        {
            return this.countries.All();
        }

        public void Create(string name)
        {
            var country = new Country()
            {
                Name = name
            };

            this.countries.Add(country);
            this.countries.SaveChanges();
        }

        public void DeleteById(int id)
        {
            this.countries.Delete(id);
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
