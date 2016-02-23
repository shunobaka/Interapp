namespace Interapp.Web.ViewModels.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Common.Constants;
    using Common.Enums;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First name")]
        [MinLength(ModelConstants.UserNamesMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.UserNamesMaxLength, ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        [RegularExpression(ModelConstants.UserNamesRegex, ErrorMessage = ModelErrorMessages.NameRegexErrorMessage)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [MinLength(ModelConstants.UserNamesMinLength, ErrorMessage = ModelErrorMessages.MinLengthErrorMessage)]
        [MaxLength(ModelConstants.UserNamesMaxLength, ErrorMessage = ModelErrorMessages.MaxLengthErrorMessage)]
        [RegularExpression(ModelConstants.UserNamesRegex, ErrorMessage = ModelErrorMessages.NameRegexErrorMessage)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [Display(Name = "Role")]
        [EnumDataType(typeof(UserRoles), ErrorMessage = "The user type is invalid.")]
        public int Role { get; set; }
    }
}
