namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentInfoStudentViewModel Student { get; set; }

        public StudentInfoUniversityViewModel University { get; set; }

        public StudentInfoEssayViewModel Essay { get; set; }

        public StudentInfoScoresViewModel Scores { get; set; }

        public StudentInfoMajorViewModel Major { get; set; }

        public IList<StudentInfoDocumentViewModel> Documents { get; set; }

        public IList<StudentInfoUniversityViewModel> UniversitiesOfInterest { get; set; }
    }
}