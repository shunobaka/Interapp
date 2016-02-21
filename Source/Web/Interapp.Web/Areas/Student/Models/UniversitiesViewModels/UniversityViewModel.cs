namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TuitionFee { get; set; }

        public IList<DocumentViewModel> DocumentRequirements { get; set; }
    }
}