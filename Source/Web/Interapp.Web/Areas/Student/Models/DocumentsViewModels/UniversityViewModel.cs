namespace Interapp.Web.Areas.Student.Models.DocumentsViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>
    {
        public string Name { get; set; }
    }
}