namespace Interapp.Web.Models.UniversityViewModels
{
    using Common.Enums;
    using CountryViewModels;
    using Data.Models;
    using DirectorInfoViewModels;
    using Infrastructure.Mappings;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int TuitionFee { get; set; }

        public int CountryId { get; set; }

        public virtual CountryViewModel Country { get; set; }
        
        public int? RequiredSAT { get; set; }
        
        public int? RequiredIBTToefl { get; set; }
        
        public int? RequiredPBTToefl { get; set; }

        public CambridgeResult? RequiredCambridgeScore { get; set; }

        public CambridgeLevel? RequiredCambridgeLevel { get; set; }

        public virtual DirectorInfoViewModel Director { get; set; }
    }
}