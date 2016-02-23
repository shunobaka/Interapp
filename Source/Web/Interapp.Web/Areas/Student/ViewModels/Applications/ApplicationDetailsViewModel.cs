namespace Interapp.Web.Areas.Student.ViewModels.Applications
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationDetailsViewModel : IMapFrom<Application>, IMapTo<Application>
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