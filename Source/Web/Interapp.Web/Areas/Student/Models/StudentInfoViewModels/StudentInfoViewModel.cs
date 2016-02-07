namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;
    using EssayViewModels;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentInfoStudentViewModel Student { get; set; }

        public StudentInfoUniversityViewModel University { get; set; }

        public EssayViewModel Essay { get; set; }

        public ScoresViewModel Scores { get; set; }

        public StudentInfoMajorViewModel Major { get; set; }

        public IList<StudentInfoDocumentViewModel> Documents { get; set; }

        public IList<StudentInfoUniversityViewModel> UniversitiesOfInterest { get; set; }
    }
}