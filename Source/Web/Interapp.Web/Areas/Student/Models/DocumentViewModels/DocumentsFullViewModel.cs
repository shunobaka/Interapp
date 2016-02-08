namespace Interapp.Web.Areas.Student.Models.DocumentViewModels
{
    using System.Collections.Generic;
    using UniversityViewModels;

    public class DocumentsFullViewModel
    {
        public ICollection<DocumentViewModel> StudentDocuments { get; set; }

        public ICollection<UniversityViewModel> Universities { get; set; }
    }
}