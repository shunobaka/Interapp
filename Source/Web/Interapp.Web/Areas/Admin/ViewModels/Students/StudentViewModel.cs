namespace Interapp.Web.Areas.Admin.ViewModels.Students
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentViewModel : IMapFrom<StudentInfo>, IMapTo<StudentInfo>, IHaveCustomMappings
    {
        public string StudentId { get; set; }

        [Display(Name = "University")]
        public int? UniversityId { get; set; }

        [Display(Name = "Major")]
        public int? MajorId { get; set; }

        public string UniversityName { get; set; }

        public string MajorName { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<StudentInfo, StudentViewModel>()
                .ForMember(s => s.UniversityName, opts => opts.MapFrom(s => s.University != null ? s.University.Name : "-----"))
                .ForMember(s => s.MajorName, opts => opts.MapFrom(s => s.Major != null ? s.Major.Name : "-----"))
                .ForMember(s => s.Name, opts => opts.MapFrom(s => s.Student.FirstName + " " + s.Student.LastName))
                .ForMember(s => s.Username, opts => opts.MapFrom(s => s.Student.UserName))
                .ForMember(s => s.Email, opts => opts.MapFrom(s => s.Student.Email));
        }
    }
}