namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Common.Enums;

    public class StudentInfoScoresViewModel
    {
        public int? SatCRResult { get; set; }
        
        public int? SatWritingResult { get; set; }
        
        public int? SatMathResult { get; set; }
        
        public int? ToeflResult { get; set; }

        public ToeflType? ToeflType { get; set; }
        
        public char? CambridgeResult { get; set; }

        public CambridgeLevel? CambridgeLevel { get; set; }
    }
}