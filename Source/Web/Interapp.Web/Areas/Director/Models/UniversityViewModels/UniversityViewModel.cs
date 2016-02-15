namespace Interapp.Web.Areas.Director.Models.UniversityViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mappings;
    using Web.Models.CountryViewModels;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UniversityNameMinLength)]
        [MaxLength(ModelConstants.UniversityNameMaxLength)]
        [RegularExpression(ModelConstants.UniversityNameRegex)]
        public string Name { get; set; }

        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax)]
        public int TuitionFee { get; set; }

        public int CountryId { get; set; }
        
        public CountryViewModel Country { get; set; }

        [Range(ModelConstants.ScoreSatTotalMin, ModelConstants.ScoreSatTotalMax)]
        public int? RequiredSAT { get; set; }

        [Range(ModelConstants.ScoreIBTToeflMin, ModelConstants.ScoreIBTToeflMax)]
        public int? RequiredIBTToefl { get; set; }

        [Range(ModelConstants.ScorePBTToelfMin, ModelConstants.ScorePBTToeflMax)]
        public int? RequiredPBTToefl { get; set; }

        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}