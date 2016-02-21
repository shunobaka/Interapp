namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DocumentViewModel> DocumentRequirements { get; set; }
    }
}