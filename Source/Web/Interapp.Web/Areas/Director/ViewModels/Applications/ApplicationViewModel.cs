namespace Interapp.Web.Areas.Director.ViewModels.Applications
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationViewModel : IMapFrom<Application>, IMapTo<Application>
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool IsAnswered { get; set; }

        public int UniversityId { get; set; }

        public UniversityViewModel University { get; set; }

        public StudentInfoViewModel Student { get; set; }

        public MajorViewModel Major { get; set; }

        public int? ResponseId { get; set; }
    }
}