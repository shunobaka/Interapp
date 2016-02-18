namespace Interapp.Web.Areas.Student.Models.ResponsesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public UniversityViewModel University { get; set; }

        public MajorViewModel Major { get; set; }
    }
}