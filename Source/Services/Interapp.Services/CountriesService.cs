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

        public Country Create(string name)
        {
            var country = new Country()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow
            };

            this.countries.Add(country);
            this.countries.Save();

            return country;
        }

        public void Delete(int id)
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

        public void Update(Country country)
        {
            var orgCountry = this.countries.GetById(country.Id);

            if (country != null)
            {
                orgCountry.Name = country.Name;
                this.countries.Save();
            }
        }
    }
}
