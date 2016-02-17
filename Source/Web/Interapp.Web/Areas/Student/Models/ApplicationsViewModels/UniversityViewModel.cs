namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class UniversityViewModel : IMapFrom<University>
    {
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}