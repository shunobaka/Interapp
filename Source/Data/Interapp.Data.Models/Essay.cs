namespace Interapp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Essay
    {
        [Required]
        [MinLength(ModelConstants.EssayTitleMinLength)]
        [MaxLength(ModelConstants.EssayTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayContentMinLength)]
        [MaxLength(ModelConstants.EssayContentMaxLength)]
        public string Content { get; set; }
        
        [Key]
        [Required]
        public string AuthorId { get; set; }
        
        [ForeignKey("AuthorId")]
        public virtual StudentInfo Author { get; set; }
    }
}
