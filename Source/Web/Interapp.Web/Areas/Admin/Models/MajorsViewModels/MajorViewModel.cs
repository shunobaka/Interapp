namespace Interapp.Web.Areas.Admin.Models.MajorsViewModels
{
    using Infrastructure.Mappings;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class MajorViewModel : IMapFrom<Major>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ModelConstants.MajorNameMaxLength,
            ErrorMessage = "The {0} must be at least {2} characters long.",
            MinimumLength = ModelConstants.MajorNameMinLength)]
        public string Name { get; set; }
    }
}