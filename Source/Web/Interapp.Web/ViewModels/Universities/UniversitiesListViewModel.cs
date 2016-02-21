namespace Interapp.Web.ViewModels.Universities
{
    using System.Collections.Generic;
    using Services.Common;

    public class UniversitiesListViewModel
    {
        public IEnumerable<UniversitySimpleViewModel> Universities { get; set; }

        public FilterModel Filter { get; set; }

        public int UniversitiesCount { get; set; }
    }
}