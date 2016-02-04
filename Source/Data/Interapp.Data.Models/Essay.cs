namespace Interapp.Data.Models
{
    using Common.Constants;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Essay
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayTitleMinLength)]
        [MaxLength(ModelConstants.EssayTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayContentMinLength)]
        [MaxLength(ModelConstants.EssayContentMaxLength)]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
