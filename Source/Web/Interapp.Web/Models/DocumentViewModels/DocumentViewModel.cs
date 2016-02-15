namespace Interapp.Web.Models.DocumentViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public string Name { get; set; }
    }
}