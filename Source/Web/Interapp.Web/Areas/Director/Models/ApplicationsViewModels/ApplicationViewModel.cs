namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool IsAnswered { get; set; }
        
        public int UniversityId { get; set; }
        
        public UniversityViewModel University { get; set; }

        public StudentInfoViewModel Student { get; set; }
        
        public MajorViewModel Major { get; set; }

        public int? ResponseId { get; set; }
    }
}