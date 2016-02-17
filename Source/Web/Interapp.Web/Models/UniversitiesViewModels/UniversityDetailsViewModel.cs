namespace Interapp.Web.Models.UniversitiesViewModels
{
    using System.Collections.Generic;
    using AutoMapper;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UniversityDetailsViewModel : IMapFrom<University>, IHaveCustomMappings
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int TuitionFee { get; set; }

        public int CountryId { get; set; }

        public virtual CountryViewModel Country { get; set; }
        
        public int? RequiredSAT { get; set; }
        
        public int? RequiredIBTToefl { get; set; }
        
        public int? RequiredPBTToefl { get; set; }

        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public virtual DirectorInfoViewModel Director { get; set; }

        public int EnrolledStudents { get; set; }

        public int InterestedStudents { get; set; }

        public ICollection<DocumentViewModel> DocumentRequirements { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<University, UniversityDetailsViewModel>()
                .ForMember(u => u.EnrolledStudents, opts => opts.MapFrom(u => u.Students.Count));

            configuration.CreateMap<University, UniversityDetailsViewModel>()
                .ForMember(u => u.InterestedStudents, opts => opts.MapFrom(u => u.InterestedStudents.Count));
        }
    }
}