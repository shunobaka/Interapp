﻿namespace Interapp.Web.Areas.Director.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }
    }
}