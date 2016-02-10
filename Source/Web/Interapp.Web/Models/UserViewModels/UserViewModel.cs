namespace Interapp.Web.Models.UserViewModels
{
    using Data.Models;
    using Infrastructure.Mappings;

    public class UserViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}