namespace Interapp.Web.Areas.Student.Models.UniversityViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using StudentInfoViewModels;
    using System.Collections.Generic;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int TuitionFee { get; set; }

        public ICollection<StudentInfoDocumentViewModel> DocumentRequirements { get; set; }
    }
}