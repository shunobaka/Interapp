namespace Interapp.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class University
    {
        private ICollection<User> students { get; set; }
        private ICollection<Document> documentsRequirement;

        public University()
        {
            this.students = new HashSet<User>();
            this.documentsRequirement = new HashSet<Document>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelConstants.UniversityNameMinLength)]
        [MaxLength(ModelConstants.UniversityNameMaxLength)]
        public string Name { get; set; }

        [Range(ModelConstants.UniversityTuitionFeeMin, ModelConstants.UniversityTuitionFeeMax)]
        public int TuitionFee { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [Required]
        public string DirectorId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual User Director { get; set; }

        public int ScoreRequirementId { get; set; }

        [ForeignKey("ScoreRequirementId")]
        public virtual Score ScoreRequirement { get; set; }

        public virtual ICollection<Document> DocumentsRequirement
        {
            get
            {
                return this.documentsRequirement;
            }

            set
            {
                this.documentsRequirement = value;
            }
        }

        public virtual ICollection<User> Students
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
    }
}
