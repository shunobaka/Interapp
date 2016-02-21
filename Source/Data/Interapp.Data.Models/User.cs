namespace Interapp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Models;
    using Interapp.Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
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

        public DateTime? DateOfBirth { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("DirectorInfo")]
        public string DirectorInfoId { get; set; }

        public virtual DirectorInfo DirectorInfo { get; set; }

        [ForeignKey("StudentInfo")]
        public string StudentInfoId { get; set; }

        public virtual StudentInfo StudentInfo { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
