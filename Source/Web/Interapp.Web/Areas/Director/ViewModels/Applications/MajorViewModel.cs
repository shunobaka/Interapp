namespace Interapp.Web.Areas.Director.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MajorViewModel : IMapFrom<Major>, IMapTo<Major>
    {
        public string Name { get; set; }
    }
}