namespace Interapp.Web.Areas.Admin.ViewModels.Scores
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Common.Constants;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ScoresViewModel : IMapFrom<ScoreReport>, IMapTo<ScoreReport>, IHaveCustomMappings
    {
        public string StudentInfoId { get; set; }

        [Display(Name = "Student")]
        public string StudentName { get; set; }

        [Display(Name = "Username")]
        public string StudentUsername { get; set; }

        [Display(Name = "SAT Critical Reading")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatCRResult { get; set; }

        [Display(Name = "SAT Writing")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatWritingResult { get; set; }

        [Display(Name = "SAT Math")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatMathResult { get; set; }

        [Display(Name = "Toefl Result")]
        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? ToeflResult { get; set; }

        [Display(Name = "Toefl Type")]
        public ToeflType? ToeflType { get; set; }

        [Display(Name = "Cambridge Mark")]
        public CambridgeResult? CambridgeResult { get; set; }

        [Display(Name = "Cambridge Level")]
        public CambridgeLevel? CambridgeLevel { get; set; }

        public string Toefl { get; set; }

        [Display(Name = "Cambridge Result")]
        public string Cambridge { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<ScoreReport, ScoresViewModel>()
                .ForMember(s => s.StudentName, opts => opts.MapFrom(s => s.StudentInfo.Student.FirstName + " " + s.StudentInfo.Student.LastName))
                .ForMember(s => s.StudentUsername, opts => opts.MapFrom(s => s.StudentInfo.Student.Email))
                .ForMember(s => s.Toefl, opts => opts.MapFrom(s => s.ToeflResult + " " + s.ToeflType))
                .ForMember(s => s.Cambridge, opts => opts.MapFrom(s => s.CambridgeLevel + " " + s.CambridgeResult));
        }
    }
}