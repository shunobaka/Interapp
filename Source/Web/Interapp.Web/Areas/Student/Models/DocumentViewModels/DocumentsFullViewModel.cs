namespace Interapp.Web.Areas.Student.Models.DocumentViewModels
{
    using System.Collections.Generic;
    using UniversityViewModels;

    public class DocumentsFullViewModel
    {
        public IList<DocumentViewModel> StudentDocuments { get; set; }

        public IList<UniversityViewModel> Universities { get; set; }
    }
}