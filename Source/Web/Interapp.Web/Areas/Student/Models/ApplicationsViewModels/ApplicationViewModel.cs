namespace Interapp.Web.Areas.Student.Models.ApplicationsViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;
    using System;

    public class ApplicationViewModel : IMapFrom<Application>
    {
        public DateTime? DateCreated { get; set; }

        public virtual University University { get; set; }

        public virtual Major Major { get; set; }
    }
}