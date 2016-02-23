namespace Interapp.Web.Areas.Director.ViewModels.Documents
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>, IMapTo<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}