namespace Interapp.Web.Areas.Director.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class EssayViewModel : IMapFrom<Essay>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}