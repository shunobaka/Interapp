namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoEssayViewModel : IMapFrom<Essay>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}