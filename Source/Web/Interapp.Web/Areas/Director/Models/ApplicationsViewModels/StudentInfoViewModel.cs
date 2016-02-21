namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentViewModel Student { get; set; }
    }
}