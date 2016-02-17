namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public string Name { get; set; }
    }
}