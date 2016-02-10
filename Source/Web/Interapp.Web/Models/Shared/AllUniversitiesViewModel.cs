namespace Interapp.Web.Models.Shared
{
    using Services.Common;
    using System.Collections.Generic;
    using UniversityViewModels;

    public class AllUniversitiesViewModel
    {
        public IEnumerable<UniversitySimpleViewModel> Universities { get; set; }

        public FilterModel Filter { get; set; }

        public int UniversitiesCount { get; set; }
    }
}