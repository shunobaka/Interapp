namespace Interapp.Web.Areas.Student.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DocumentViewModel : IMapFrom<Document>, IMapTo<Document>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.DocumentNameMinLength)]
        [MaxLength(ModelConstants.DocumentNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        public UniversityViewModel University { get; set; }

        public int? UniversityId { get; set; }

        public string AuthorId { get; set; }
    }
}