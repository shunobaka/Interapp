namespace Interapp.Web.Areas.Student.Models.ResponsesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class ResponseViewModel : IMapFrom<Response>
    {
        public string Content { get; set; }

        public bool IsAdmitted { get; set; }

        public ApplicationViewModel Application { get; set; }
    }
}