namespace Interapp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;

    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.DocumentNameMinLength)]
        [MaxLength(ModelConstants.DocumentNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }
        
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
