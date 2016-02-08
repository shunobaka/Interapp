namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoMajorViewModel : IMapFrom<Major>
    {
        public string Name { get; set; }
    }
}