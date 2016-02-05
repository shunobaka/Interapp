namespace Interapp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Response
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual StudentInfo Student { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }

        [Required]
        [MinLength(ModelConstants.ResponseContentMinLength)]
        [MaxLength(ModelConstants.ResponseContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public bool IsAdmitted { get; set; }
    }
}
