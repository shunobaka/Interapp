namespace Interapp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;
    using Common.Enums;

    public class University
    {
        private ICollection<StudentInfo> students;
        private ICollection<StudentInfo> interestedStudents;
        private ICollection<Document> documentRequirements;
        private ICollection<Response> responses;

        public University()
        {
            this.students = new HashSet<StudentInfo>();
            this.interestedStudents = new HashSet<StudentInfo>();
            this.documentRequirements = new HashSet<Document>();
            this.responses = new HashSet<Response>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelConstants.UniversityNameMinLength)]
        [MaxLength(ModelConstants.UniversityNameMaxLength)]
        [RegularExpression(ModelConstants.UniversityNameRegex)]
        public string Name { get; set; }

        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax)]
        public int TuitionFee { get; set; }
        
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Range(ModelConstants.ScoreSatTotalMin, ModelConstants.ScoreSatTotalMax)]
        public int? RequiredSAT { get; set; }

        [Range(ModelConstants.ScoreIBTToeflMin, ModelConstants.ScoreIBTToeflMax)]
        public int? RequiredIBTToefl { get; set; }

        [Range(ModelConstants.ScorePBTToelfMin, ModelConstants.ScorePBTToeflMax)]
        public int? RequiredPBTToefl { get; set; }
        
        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        [Required]
        public string DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual DirectorInfo Director { get; set; }

        public virtual ICollection<Document> DocumentRequirements
        {
            get
            {
                return this.documentRequirements;
            }

            set
            {
                this.documentRequirements = value;
            }
        }

        [InverseProperty("UniversitiesOfInterest")]
        public virtual ICollection<StudentInfo> InterestedStudents
        {
            get
            {
                return this.interestedStudents;
            }

            set
            {
                this.interestedStudents = value;
            }
        }

        [InverseProperty("University")]
        public virtual ICollection<StudentInfo> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
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
