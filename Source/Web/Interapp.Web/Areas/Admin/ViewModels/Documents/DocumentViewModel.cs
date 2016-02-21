namespace Interapp.Web.Areas.Admin.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class DocumentViewModel : IMapFrom<Document>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.DocumentNameMinLength)]
        [MaxLength(ModelConstants.DocumentNameMaxLength)]
        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public string UniversityName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Document, DocumentViewModel>()
                .ForMember(d => d.AuthorName, opts => opts.MapFrom(d => d.Author != null ? d.Author.Student.FirstName + " " + d.Author.Student.LastName : "None"))
                .ForMember(d => d.UniversityName, opts => opts.MapFrom(d => d.University != null ? d.University.Name : "None"));
        }
    }
}