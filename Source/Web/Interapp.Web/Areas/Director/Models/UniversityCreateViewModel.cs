namespace Interapp.Web.Areas.Director.Models
{
    using Common.Constants;
    using Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class UniversityCreateViewModel
    {
        [Required]
        [Display(Name = "University name")]
        [MinLength(ModelConstants.UniversityNameMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.UniversityNameMaxLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [RegularExpression(ModelConstants.UniversityNameRegex)]
        public string Name { get; set; }

        [Display(Name = "Tuition fee")]
        [Required]
        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax, ErrorMessage = "{0} must be between {1:C} and {2:C}")]
        public int TuitionFee { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}