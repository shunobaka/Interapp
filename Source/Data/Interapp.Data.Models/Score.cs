namespace Interapp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Common.Enums;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Score
    {
        [Key]
        public int Id { get; set; }


        public int RequiredSAT { get; set; }

        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? RequiredIBTToefl { get; set; }

        [Range(ModelConstants.ScoreToeflMin, ModelConstants.ScoreToeflMax)]
        public int? RequiredPBTToefl { get; set; }


        [RegularExpression(ModelConstants.ScoreCambridgeResultRegex)]
        public char? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        //public string StudentId { get; set; }

        //[ForeignKey("StudentId")]
        //public virtual User Student { get; set; }

        //public int? UniversityId { get; set; }

        //[ForeignKey("UniversityId")]
        //public virtual University University { get; set; }
    }
}
