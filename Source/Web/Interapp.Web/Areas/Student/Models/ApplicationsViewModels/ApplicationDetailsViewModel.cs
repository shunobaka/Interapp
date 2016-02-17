namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System;

    public class ApplicationDetailsViewModel : IMapFrom<Application>
    {
        public DateTime? DateCreated { get; set; }

        public bool IsReviewed { get; set; }

        public bool IsAnswered { get; set; }
        
        public int UniversityId { get; set; }
        
        public virtual University University { get; set; }
        
        public virtual Major Major { get; set; }
    }
}