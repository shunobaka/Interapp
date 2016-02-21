namespace Interapp.Web.Areas.Admin.ViewModels.Responses
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ResponseViewModel : IMapFrom<Response>, IMapTo<Response>, IHaveCustomMappings
    {
        public int ApplicationId { get; set; }

        [Required]
        [MinLength(ModelConstants.ResponseContentMinLength)]
        [MaxLength(ModelConstants.ResponseContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Is admitted")]
        public bool IsAdmitted { get; set; }

        [Display(Name = "Student name")]
        public string StudentName { get; set; }

        [Display(Name = "Username")]
        public string StudentUsername { get; set; }

        [Display(Name = "University name")]
        public string UniversityName { get; set; }

        [Display(Name = "Student email")]
        public string StudentEmail { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Response, ResponseViewModel>()
                .ForMember(r => r.StudentName, opts => opts.MapFrom(r => r.Application.Student.Student.FirstName + " " + r.Application.Student.Student.LastName))
                .ForMember(r => r.StudentUsername, opts => opts.MapFrom(r => r.Application.Student.Student.UserName))
                .ForMember(r => r.UniversityName, opts => opts.MapFrom(r => r.Application.University.Name))
                .ForMember(r => r.StudentEmail, opts => opts.MapFrom(r => r.Application.Student.Student.Email));
        }
    }
}