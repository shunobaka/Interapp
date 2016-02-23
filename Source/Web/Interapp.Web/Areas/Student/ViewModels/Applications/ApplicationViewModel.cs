namespace Interapp.Web.Areas.Student.ViewModels.Applications
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ApplicationViewModel : IMapFrom<Application>, IMapTo<Application>
    {
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public UniversityViewModel University { get; set; }
    }
}