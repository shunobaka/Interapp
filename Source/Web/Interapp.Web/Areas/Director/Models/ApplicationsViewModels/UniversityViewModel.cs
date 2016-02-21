namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class UniversityViewModel : IMapFrom<University>
    {
        public string Name { get; set; }
    }
}