namespace Interapp.Web.Areas.Admin.ViewModels.Countries
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>, IMapTo<Country>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(
            ModelConstants.CountryNameMinLength,
            ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(
            ModelConstants.CountryNameMaxLenght,
            ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        public string Name { get; set; }

        public int UsersCount { get; set; }

        public int UniversitiesCount { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Country, CountryViewModel>()
                .ForMember(c => c.UsersCount, opts => opts.MapFrom(c => c.Users.Count))
                .ForMember(c => c.UniversitiesCount, opts => opts.MapFrom(c => c.Universities.Count));
        }
    }
}