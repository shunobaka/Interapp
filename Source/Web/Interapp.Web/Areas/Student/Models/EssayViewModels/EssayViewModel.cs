namespace Interapp.Web.Areas.Student.Models.EssayViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class EssayViewModel : IMapFrom<Essay>
    {
        [Required]
        [MinLength(ModelConstants.EssayTitleMinLength,
            ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.EssayTitleMaxLength,
            ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayContentMinLength,
            ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.EssayContentMaxLength,
            ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        public string Content { get; set; }
    }
}