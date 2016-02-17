namespace Interapp.Web.Areas.Student.Models.UniversitiesViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ApplicationInputViewModel
    {
        public int UniversityId { get; set; }

        public int MajorId { get; set; }

        public IEnumerable<SelectListItem> Majors { get; set; }
    }
}