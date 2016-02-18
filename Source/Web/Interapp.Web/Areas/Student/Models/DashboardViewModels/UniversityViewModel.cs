namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System.Collections.Generic;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DocumentViewModel> DocumentRequirements { get; set; }
    }
}