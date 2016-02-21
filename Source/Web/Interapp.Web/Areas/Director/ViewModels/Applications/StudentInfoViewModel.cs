namespace Interapp.Web.Areas.Director.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentViewModel Student { get; set; }
    }
}