namespace Interapp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Constants;
    using Common.Enums;

    public class ScoreReport
    {
        [Key]
        [Required]
        public string StudentInfoId { get; set; }

        [ForeignKey("StudentInfoId")]
        public virtual StudentInfo StudentInfo { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatCRResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatWritingResult { get; set; }

        [Range(ModelConstants.ScoreSatMin, ModelConstants.ScoreSatMax)]
        public int? SatMathResult { get; set; }

        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? ToeflResult { get; set; }

        public ToeflType? ToeflType { get; set; }

        [RegularExpression(ModelConstants.ScoreCambridgeResultRegex)]
        public char? CambridgeResult { get; set; }

        public CambridgeLevel? CambridgeLevel { get; set; }
    }
}
