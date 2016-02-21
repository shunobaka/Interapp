namespace Interapp.Web.Areas.Director.ViewModels.Documents
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UniversityViewModel University { get; set; }
    }
}