namespace Interapp.Web.Areas.Admin.ViewModels.Universities
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UniversityNameMinLength)]
        [MaxLength(ModelConstants.UniversityNameMaxLength)]
        [RegularExpression(ModelConstants.UniversityNameRegex)]
        public string Name { get; set; }

        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax)]
        public int TuitionFee { get; set; }

        [Display(Name = "Country")]
        public string CountryName { get; set; }

        [Display(Name = "Director")]
        public string DirectorName { get; set; }

        [Display(Name = "SAT")]
        [Range(ModelConstants.ScoreSatTotalMin, ModelConstants.ScoreSatTotalMax)]
        public int? RequiredSAT { get; set; }

        [Display(Name = "IBT TOEFL")]
        [Range(ModelConstants.ScoreIBTToeflMin, ModelConstants.ScoreIBTToeflMax)]
        public int? RequiredIBTToefl { get; set; }

        [Display(Name = "PBT TOEFL")]
        [Range(ModelConstants.ScorePBTToelfMin, ModelConstants.ScorePBTToeflMax)]
        public int? RequiredPBTToefl { get; set; }

        [Display(Name = "Cambridge Level")]
        public CambridgeResult? RequiredCambridgeScore { get; set; }

        [Display(Name = "Cambridge Score")]
        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<University, UniversityViewModel>()
                .ForMember(u => u.CountryName, opts => opts.MapFrom(u => u.Country.Name))
                .ForMember(u => u.DirectorName, opts => opts.MapFrom(u => u.Director.Director.FirstName + " " + u.Director.Director.LastName));
        }
    }
}