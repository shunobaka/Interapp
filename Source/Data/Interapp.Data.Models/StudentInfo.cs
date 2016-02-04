namespace Interapp.Data.Models
{
    using Common.Constants;
    using Common.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StudentInfo
    {
        private ICollection<Application> applications;
        private ICollection<Document> documents;

        public StudentInfo()
        {
            this.applications = new HashSet<Application>();
            this.documents = new HashSet<Document>();
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

        public int? MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatCRResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatWritingResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatMathResult { get; set; }

        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? ToeflResult { get; set; }

        public ToeflType? ToeflType { get; set; }

        [RegularExpression(ModelConstants.ScoreCambridgeResultRegex)]
        public char? CambridgeResult { get; set; }

        public CambridgeLevel? CambridgeLevel { get; set; }

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
    }
}
