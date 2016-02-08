namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;
    using EssayViewModels;
    using ScoresViewModels;
    using UniversityViewModels;

    public class StudentInfoViewModel : IMapFrom<StudentInfo>
    {
        public StudentInfoStudentViewModel Student { get; set; }

        public UniversityViewModel University { get; set; }

        public EssayViewModel Essay { get; set; }

        public ScoresViewModel Scores { get; set; }

        public StudentInfoMajorViewModel Major { get; set; }

        public IList<StudentInfoDocumentViewModel> Documents { get; set; }

        public IList<UniversityViewModel> UniversitiesOfInterest { get; set; }
    }
}