namespace Interapp.Web.Areas.Director.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class DocumentInputViewModel
    {
        [Required]
        [Display(Name = "University")]
        public int UniversityId { get; set; }

        [Required]
        [MinLength(
            ModelConstants.DocumentNameMinLength,
            ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(
            ModelConstants.DocumentNameMaxLength,
            ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }
    }
}