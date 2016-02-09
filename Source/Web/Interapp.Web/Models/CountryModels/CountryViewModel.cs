namespace Interapp.Web.Models.CountryModels
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;

    public class CountryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.CountryNameMinLength)]
        [MaxLength(ModelConstants.CountryNameMaxLenght)]
        public string Name { get; set; }
    }
}