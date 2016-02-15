namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;
    using ScoresViewModels;

    public class StudentInfoApplicationViewModel : IMapFrom<StudentInfo>
    {
        public ScoresViewModel Scores { get; set; }

        public IList<StudentInfoDocumentViewModel> Documents { get; set; }
    }
}