namespace Interapp.Web.Areas.Director.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentInfoDetailsViewModel : IMapFrom<StudentInfo>, IMapTo<StudentInfo>
    {
        public StudentViewModel Student { get; set; }

        public ScoresViewModel Scores { get; set; }

        public EssayViewModel Essay { get; set; }
    }
}