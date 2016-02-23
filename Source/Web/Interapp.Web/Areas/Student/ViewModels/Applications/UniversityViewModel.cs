namespace Interapp.Web.Areas.Student.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>, IMapTo<University>
    {
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}