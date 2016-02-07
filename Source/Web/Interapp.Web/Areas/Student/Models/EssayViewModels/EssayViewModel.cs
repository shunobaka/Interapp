namespace Interapp.Web.Areas.Student.Models.EssayViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class EssayViewModel : IMapFrom<Essay>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}