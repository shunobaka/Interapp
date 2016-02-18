namespace Interapp.Web.Areas.Admin.Models.UsersViewModels
{
    using Infrastructure.Mappings;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class UserViewModel : IMapFrom<User>
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UserNamesMinLength)]
        [MaxLength(ModelConstants.UserNamesMaxLength)]
        [RegularExpression(ModelConstants.UserNamesRegex)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserNamesMinLength)]
        [MaxLength(ModelConstants.UserNamesMaxLength)]
        [RegularExpression(ModelConstants.UserNamesRegex)]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}