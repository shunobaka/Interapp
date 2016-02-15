namespace Interapp.Web.Models.CountryViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }
    }
}