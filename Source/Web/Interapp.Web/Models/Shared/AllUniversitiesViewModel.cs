namespace Interapp.Web.Models.Shared
{
    using Common.Enums;
    using Services.Common;
    using System.Collections.Generic;
    using UniversityViewModels;

    public class AllUniversitiesViewModel
    {
        public IEnumerable<UniversityViewModel> Universities { get; set; }

        public FilterModel Filter { get; set; }

        public int UniversitiesCount { get; set; }
    }
}