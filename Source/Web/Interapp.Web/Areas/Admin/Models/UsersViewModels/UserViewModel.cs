namespace Interapp.Web.Areas.Admin.Models.UsersViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UserNamesMinLength)]
        [MaxLength(ModelConstants.UserNamesMaxLength)]
        [RegularExpression(ModelConstants.UserNamesRegex)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(ModelConstants.UserNamesMinLength)]
        [MaxLength(ModelConstants.UserNamesMaxLength)]
        [RegularExpression(ModelConstants.UserNamesRegex)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}