namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class ResponseInputModel : IMapFrom<Response>
    {
        [Required]
        [MinLength(ModelConstants.ResponseContentMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.ResponseContentMaxLength, ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        [Display(Name = "Response message")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Is admitted")]
        public bool IsAdmitted { get; set; }
    }
}