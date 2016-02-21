namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Common.Enums;
    using Data.Models;
    using Infrastructure.Mappings;

    public class ScoresViewModel : IMapFrom<ScoreReport>
    {
        public string StudentInfoId { get; set; }

        public virtual StudentInfo StudentInfo { get; set; }

        public int? SatCRResult { get; set; }

        public int? SatWritingResult { get; set; }

        public int? SatMathResult { get; set; }

        public int? ToeflResult { get; set; }

        public ToeflType? ToeflType { get; set; }

        public CambridgeResult? CambridgeResult { get; set; }

        public CambridgeLevel? CambridgeLevel { get; set; }
    }
}