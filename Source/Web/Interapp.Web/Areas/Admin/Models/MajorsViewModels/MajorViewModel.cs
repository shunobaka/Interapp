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
        [MinLength(ModelConstants.MajorNameMinLength)]
        [MaxLength(ModelConstants.MajorNameMaxLength)]
        public string Name { get; set; }
    }
}