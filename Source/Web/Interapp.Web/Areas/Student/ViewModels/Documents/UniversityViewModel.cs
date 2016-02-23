namespace Interapp.Web.Areas.Student.ViewModels.Documents
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>, IMapTo<University>
    {
        public string Name { get; set; }
    }
}