namespace Interapp.Web.Models.CountryViewModels
{
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using System.ComponentModel.DataAnnotations;

    public class CountryViewModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.CountryNameMinLength)]
        [MaxLength(ModelConstants.CountryNameMaxLenght)]
        public string Name { get; set; }
    }
}