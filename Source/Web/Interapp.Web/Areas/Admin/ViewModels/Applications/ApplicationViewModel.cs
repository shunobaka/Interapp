namespace Interapp.Web.Areas.Admin.ViewModels.Applications
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationViewModel : IMapFrom<Application>, IMapTo<Application>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public bool IsReviewed { get; set; }

        public bool IsAnswered { get; set; }

        [Display(Name = "Major")]
        public int MajorId { get; set; }

        [Display(Name = "Student name")]
        public string StudentName { get; set; }

        [Display(Name = "Username")]
        public string StudentUsername { get; set; }

        [Display(Name = "University name")]
        public string UniversityName { get; set; }

        [Display(Name = "Student email")]
        public string StudentEmail { get; set; }

        [Display(Name = "Major name")]
        public string MajorName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Application, ApplicationViewModel>()
                .ForMember(a => a.MajorName, opts => opts.MapFrom(a => a.Major.Name))
                .ForMember(a => a.StudentName, opts => opts.MapFrom(a => a.Student.Student.FirstName + " " + a.Student.Student.LastName))
                .ForMember(a => a.StudentUsername, opts => opts.MapFrom(a => a.Student.Student.UserName))
                .ForMember(a => a.UniversityName, opts => opts.MapFrom(a => a.University.Name))
                .ForMember(a => a.StudentEmail, opts => opts.MapFrom(a => a.Student.Student.Email));
        }
    }
}