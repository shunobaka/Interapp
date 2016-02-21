namespace Interapp.Web.Areas.Student.ViewModels.Universities
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MajorViewModel : IMapFrom<Major>
    {
        public string Name { get; set; }
    }
}