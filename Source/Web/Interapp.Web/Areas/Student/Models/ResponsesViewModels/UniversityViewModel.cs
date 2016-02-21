namespace Interapp.Web.Areas.Student.Models.ResponsesViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}