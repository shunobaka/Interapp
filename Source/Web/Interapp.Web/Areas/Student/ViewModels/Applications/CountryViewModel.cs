namespace Interapp.Web.Areas.Student.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class CountryViewModel : IMapFrom<Country>, IMapTo<Country>
    {
        public string Name { get; set; }
    }
}