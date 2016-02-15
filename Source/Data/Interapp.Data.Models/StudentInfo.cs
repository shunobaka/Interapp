namespace Interapp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;
    using Common.Enums;

    public class StudentInfo
    {
        private ICollection<University> universitiesOfInterest;
        private ICollection<Application> applications;
        private ICollection<Document> documents;
        private ICollection<Response> responses;

        public StudentInfo()
        {
            this.universitiesOfInterest = new HashSet<University>();
            this.applications = new HashSet<Application>();
            this.documents = new HashSet<Document>();
            this.responses = new HashSet<Response>();
        }

        [Key]
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        public int? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }

        [ForeignKey("Essay")]
        public string EssayId { get; set; }
        
        public virtual Essay Essay { get; set; }

        [ForeignKey("Scores")]
        public string ScoresId { get; set; }
        
        public virtual ScoreReport Scores { get; set; }

        public int? MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        public virtual ICollection<Application> Applications
        {
            get
            {
                return this.applications;
            }

            set
            {
                this.applications = value;
            }
        }

        public virtual ICollection<Document> Documents
        {
            get
            {
                return this.documents;
            }

            set
            {
                this.documents = value;
            }
        }

        public virtual ICollection<University> UniversitiesOfInterest
        {
            get
            {
                return this.universitiesOfInterest;
            }

            set
            {
                this.universitiesOfInterest = value;
            }
        }

        public virtual ICollection<Response> Responses
        {
            get
            {
                return this.responses;
            }

            set
            {
                this.responses = value;
            }
        }
    }
}
