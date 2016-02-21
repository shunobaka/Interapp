namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}