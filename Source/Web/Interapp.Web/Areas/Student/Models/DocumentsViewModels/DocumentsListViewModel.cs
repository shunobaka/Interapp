namespace Interapp.Web.Areas.Student.Models.DocumentsViewModels
{
    using System.Collections.Generic;

    public class DocumentsListViewModel
    {
        public IList<DocumentViewModel> StudentDocuments { get; set; }

        public IList<DocumentViewModel> RequiredDocuments { get; set; }
    }
}