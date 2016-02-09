namespace Interapp.Web.Areas.Director.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class UniversityCreateViewModel
    {
        [Required]
        [Display(Name = "University name")]
        [MinLength(ModelConstants.UniversityNameMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.UniversityNameMaxLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [RegularExpression(ModelConstants.UniversityNameRegex)]
        public string Name { get; set; }

        [Display(Name = "Tuition fee")]
        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax, ErrorMessage = "{0} must be between {1:C} and {2:C}")]
        public int TuitionFee { get; set; }
    }
}