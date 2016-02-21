namespace Interapp.Web.Areas.Admin.Models.MajorsViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;

    public class MajorViewModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(
            ModelConstants.MajorNameMaxLength,
            ErrorMessage = "The {0} must be at least {2} characters long.",
            MinimumLength = ModelConstants.MajorNameMinLength)]
        public string Name { get; set; }
    }
}