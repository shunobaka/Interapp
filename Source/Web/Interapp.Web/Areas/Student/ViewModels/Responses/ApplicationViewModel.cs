namespace Interapp.Web.Areas.Student.ViewModels.Responses
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public UniversityViewModel University { get; set; }

        public MajorViewModel Major { get; set; }
    }
}