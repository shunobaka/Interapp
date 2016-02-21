namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MajorViewModel : IMapFrom<Major>
    {
        public string Name { get; set; }
    }
}