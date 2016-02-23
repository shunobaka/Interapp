namespace Interapp.Web.Areas.Director.ViewModels.Home
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>, IMapTo<Country>
    {
        public string Name { get; set; }
    }
}