namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoStudentViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}