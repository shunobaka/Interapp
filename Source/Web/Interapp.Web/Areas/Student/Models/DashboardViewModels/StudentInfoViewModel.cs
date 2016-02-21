namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentViewModel Student { get; set; }

        public EssayViewModel Essay { get; set; }

        public ScoresViewModel Scores { get; set; }

        public IList<DocumentViewModel> Documents { get; set; }

        public IList<UniversityViewModel> UniversitiesOfInterest { get; set; }
    }
}