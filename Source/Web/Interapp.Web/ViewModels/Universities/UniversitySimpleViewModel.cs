namespace Interapp.Web.ViewModels.Universities
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversitySimpleViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TuitionFee { get; set; }

        public int CountryId { get; set; }

        public CountryViewModel Country { get; set; }
    }
}