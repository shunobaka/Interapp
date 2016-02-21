namespace Interapp.Web.Areas.Director.ViewModels.Universities
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }
    }
}