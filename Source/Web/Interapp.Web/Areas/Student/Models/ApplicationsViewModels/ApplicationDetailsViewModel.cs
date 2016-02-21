namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ApplicationDetailsViewModel : IMapFrom<Application>
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool IsReviewed { get; set; }

        public bool IsAnswered { get; set; }

        public int UniversityId { get; set; }

        public UniversityViewModel University { get; set; }

        public MajorViewModel Major { get; set; }
    }
}