namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoDetailsViewModel : IMapFrom<StudentInfo>
    {
        public StudentViewModel Student { get; set; }

        public ScoresViewModel Scores { get; set; }

        public EssayViewModel Essay { get; set; }
    }
}