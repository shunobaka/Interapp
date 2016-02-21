namespace Interapp.Web.Areas.Student.ViewModels.Responses
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ResponseViewModel : IMapFrom<Response>
    {
        public int ApplicationId { get; set; }

        public string Content { get; set; }

        public bool IsAdmitted { get; set; }

        public DateTime? Date { get; set; }

        public ApplicationViewModel Application { get; set; }
    }
}