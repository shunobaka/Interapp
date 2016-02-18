namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class CountryViewModel : IMapFrom<Country>
    {
        public string Name { get; set; }
    }
}