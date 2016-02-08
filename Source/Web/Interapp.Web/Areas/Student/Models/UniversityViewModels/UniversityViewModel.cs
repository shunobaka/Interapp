namespace Interapp.Web.Areas.Student.Models.UniversityViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;
    using StudentInfoViewModels;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int TuitionFee { get; set; }

        public IList<StudentInfoDocumentViewModel> DocumentRequirements { get; set; }
    }
}