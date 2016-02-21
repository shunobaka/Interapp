namespace Interapp.Web.ViewModels.Universities
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class DocumentViewModel : IMapFrom<Document>
    {
        public string Name { get; set; }
    }
}