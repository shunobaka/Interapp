namespace Interapp.Web.Areas.Director.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IList<UniversityViewModel> Universities { get; set; }

        public int UniversitiesCount { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}