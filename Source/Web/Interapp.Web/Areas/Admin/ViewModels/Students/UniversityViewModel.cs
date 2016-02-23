namespace Interapp.Web.Areas.Admin.ViewModels.Students
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class UniversityViewModel : IMapFrom<University>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}