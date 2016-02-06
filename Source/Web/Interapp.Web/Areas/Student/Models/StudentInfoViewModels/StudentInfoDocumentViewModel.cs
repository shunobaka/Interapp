namespace Interapp.Web.Areas.Student.Models.StudentInfoViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class StudentInfoDocumentViewModel : IMapFrom<Document>
    {
        public string Name { get; set; }
    }
}