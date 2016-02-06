namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System.Collections.Generic;

    public class StudentInfoUniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int TuitionFee { get; set; }

        public ICollection<StudentInfoDocumentViewModel> DocumentRequirements { get; set; }
    }
}