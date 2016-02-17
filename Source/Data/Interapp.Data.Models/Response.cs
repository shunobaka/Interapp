namespace Interapp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Response
    {
        [Key]
        [ForeignKey("Application")]
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

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
