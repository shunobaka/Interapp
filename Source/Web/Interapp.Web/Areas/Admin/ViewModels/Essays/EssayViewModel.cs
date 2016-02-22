namespace Interapp.Web.Areas.Admin.ViewModels.Essays
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EssayViewModel : IMapFrom<Essay>, IMapTo<Essay>, IHaveCustomMappings
    {
        public string AuthorId { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayTitleMinLength)]
        [MaxLength(ModelConstants.EssayTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(ModelConstants.EssayContentMinLength)]
        [MaxLength(ModelConstants.EssayContentMaxLength)]
        public string Content { get; set; }

        public string StudentName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Essay, EssayViewModel>()
                .ForMember(e => e.StudentName, opts => opts.MapFrom(e => e.Author.Student.FirstName + " " + e.Author.Student.LastName));
        }
    }
}