namespace Interapp.Web.Areas.Director.ViewModels.Universities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>, IMapTo<University>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UniversityNameMinLength, ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        [MaxLength(ModelConstants.UniversityNameMaxLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [RegularExpression(ModelConstants.UniversityNameRegex, ErrorMessage = "University name may contain only Letters, Dashes, Brackets, Comma, Apostrophe, Whitespaces and &.")]
        public string Name { get; set; }

        [Display(Name = "Tuition fee")]
        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax)]
        public int TuitionFee { get; set; }

        public int CountryId { get; set; }

        public CountryViewModel Country { get; set; }

        [Display(Name = "Required SAT Score")]
        [Range(ModelConstants.ScoreSatTotalMin, ModelConstants.ScoreSatTotalMax)]
        public int? RequiredSAT { get; set; }

        [Display(Name = "Required IBT TOEFL Score")]
        [Range(ModelConstants.ScoreIBTToeflMin, ModelConstants.ScoreIBTToeflMax)]
        public int? RequiredIBTToefl { get; set; }

        [Display(Name = "Required PBT TOEFL Score")]
        [Range(ModelConstants.ScorePBTToelfMin, ModelConstants.ScorePBTToeflMax)]
        public int? RequiredPBTToefl { get; set; }

        [Display(Name = "Required Cambridge Certificate Mark")]
        public CambridgeResult? RequiredCambridgeScore { get; set; }

        [Display(Name = "Required Cambridge Certificate Level")]
        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        [Display(Name = "Country")]
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}