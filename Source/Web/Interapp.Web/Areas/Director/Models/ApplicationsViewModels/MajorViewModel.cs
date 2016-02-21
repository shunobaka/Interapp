namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class MajorViewModel : IMapFrom<Major>
    {
        public string Name { get; set; }
    }
}