namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using System.Collections.Generic;

    public class StudentInfoViewModel
    {
        public StudentInfoStudentViewModel Student { get; set; }
        
        public StudentInfoUniversityViewModel University { get; set; }

        public StudentInfoEssayViewModel Essay { get; set; }

        public StudentInfoScoresViewModel Scores { get; set; }

        public StudentInfoMajorViewModel Major { get; set; }

        public ICollection<StudentInfoDocumentViewModel> Documents { get; set; }
    }
}