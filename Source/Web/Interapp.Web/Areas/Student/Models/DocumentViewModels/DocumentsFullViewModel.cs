namespace Interapp.Web.Areas.Student.Models.DocumentViewModels
{
    using System.Collections.Generic;
    using UniversityViewModels;

    public class DocumentsFullViewModel
    {
        public IList<DocumentViewModel> StudentDocuments { get; set; }

        public IList<DocumentViewModel> RequiredDocuments { get; set; }
    }
}