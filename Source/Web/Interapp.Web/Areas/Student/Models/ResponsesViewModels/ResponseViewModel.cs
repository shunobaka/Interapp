namespace Interapp.Web.Areas.Student.Models.ResponsesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System;

    public class ResponseViewModel : IMapFrom<Response>
    {
        public int ApplicationId { get; set; }

        public string Content { get; set; }

        public bool IsAdmitted { get; set; }

        public DateTime? Date { get; set; }

        public ApplicationViewModel Application { get; set; }
    }
}