namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentInfoApplicationViewModel : IMapFrom<StudentInfo>
    {
        public ScoresViewModel Scores { get; set; }

        public IList<DocumentViewModel> Documents { get; set; }
    }
}