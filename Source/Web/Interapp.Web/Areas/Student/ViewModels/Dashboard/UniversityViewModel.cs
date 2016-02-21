namespace Interapp.Web.Areas.Student.ViewModels.Dashboard
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DocumentViewModel> DocumentRequirements { get; set; }
    }
}