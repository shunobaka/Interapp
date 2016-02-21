namespace Interapp.Web.Areas.Student.ViewModels.Applications
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public UniversityViewModel University { get; set; }
    }
}