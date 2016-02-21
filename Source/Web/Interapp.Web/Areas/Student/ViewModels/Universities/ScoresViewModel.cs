namespace Interapp.Web.Areas.Student.ViewModels.Universities
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ScoresViewModel : IMapFrom<ScoreReport>
    {
        [Display(Name = "SAT Critical Reading")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatCRResult { get; set; }

        [Display(Name = "SAT Writing")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatWritingResult { get; set; }

        [Display(Name = "SAT Math")]
        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatMathResult { get; set; }

        [Display(Name = "TOEFL Result")]
        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? ToeflResult { get; set; }

        [Display(Name = "Type of TOEFL")]
        public ToeflType? ToeflType { get; set; }

        [Display(Name = "Cambridge Mark")]
        public CambridgeResult? CambridgeResult { get; set; }

        [Display(Name = "Cambridge Level")]
        public CambridgeLevel? CambridgeLevel { get; set; }
    }
}