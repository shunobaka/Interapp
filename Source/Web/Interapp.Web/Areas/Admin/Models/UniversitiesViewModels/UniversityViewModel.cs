﻿namespace Interapp.Web.Areas.Admin.Models.UniversitiesViewModels
{
    using Infrastructure.Mappings;
    using Data.Models;
    using AutoMapper;
    using Common.Enums;

    public class UniversityViewModel : IMapFrom<University>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int TuitionFee { get; set; }
        
        public string CountryName { get; set; }
        
        public int? RequiredSAT { get; set; }
        
        public int? RequiredIBTToefl { get; set; }
        
        public int? RequiredPBTToefl { get; set; }

        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<University, UniversityViewModel>()
                .ForMember(u => u.CountryName, opts => opts.MapFrom(u => u.Country.Name));
        }
    }
}