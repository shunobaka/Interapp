namespace Interapp.Web.Areas.Admin.Models.UsersViewModels
{
    using Infrastructure.Mappings;
    using Data.Models;
    using System;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}