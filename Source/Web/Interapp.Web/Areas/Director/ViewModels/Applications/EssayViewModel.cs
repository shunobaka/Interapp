namespace Interapp.Web.Areas.Director.ViewModels.Applications
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class EssayViewModel : IMapFrom<Essay>, IMapTo<Essay>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}