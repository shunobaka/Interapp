namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System.Collections.Generic;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentViewModel Student { get; set; }

        public EssayViewModel Essay { get; set; }

        public ScoresViewModel Scores { get; set; }

        public IList<DocumentViewModel> Documents { get; set; }

        public IList<UniversityViewModel> UniversitiesOfInterest { get; set; }
    }
}