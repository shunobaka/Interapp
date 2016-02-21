namespace Interapp.Web.Areas.Student.Models.DashboardViewModels
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class StudentViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}