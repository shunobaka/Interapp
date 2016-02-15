namespace Interapp.Web.Areas.Student.Models.ApplicationViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using StudentInfoViewModels;
    using System;
    using System.ComponentModel.DataAnnotations;
    using UniversityViewModels;
    public class ApplicationViewModel : IMapFrom<Application>
    {
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool IsReviewed { get; set; }

        [Required]
        public int UniversityId { get; set; }
        
        public virtual UniversityViewModel University { get; set; }

        [Required]
        public string StudentId { get; set; }
        
        public virtual StudentInfoViewModel Student { get; set; }

        [Required]
        public int MajorId { get; set; }
        
        public virtual Major Major { get; set; }
    }
}