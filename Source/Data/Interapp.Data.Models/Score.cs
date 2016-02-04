namespace Interapp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Common.Enums;

    public class Score
    {
        [Key]
        public int Id { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatCRResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatWritingResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatMathResult { get; set; }

        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? ToeflResult { get; set; }

        public ToeflType ToeflType { get; set; }

        [RegularExpression(ModelConstants.ScoreCambridgeResultRegex)]
        public char? CambridgeResult { get; set; }

        public CambridgeLevel CambridgeLevel { get; set; }
    }
}
