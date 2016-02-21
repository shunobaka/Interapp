namespace Interapp.Web.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }
    }
}