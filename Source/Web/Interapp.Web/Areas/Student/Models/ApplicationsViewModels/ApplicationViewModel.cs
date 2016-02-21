namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public UniversityViewModel University { get; set; }
    }
}