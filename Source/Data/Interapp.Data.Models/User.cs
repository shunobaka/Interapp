﻿namespace Interapp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Application> applications;
        private ICollection<Document> documents;

        public User()
        {
            this.applications = new HashSet<Application>();
            this.documents = new HashSet<Document>();
        }

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
        
        public DateTime DateOfBrith { get; set; }
        
        public int? UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; }

        public int? EssayId { get; set; }

        [ForeignKey("EssayId")]
        public virtual Essay Essay { get; set; }

        public int? MajorId { get; set; }

        [ForeignKey("MajorId")]
        public virtual Major Major { get; set; }

        [Required]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int? ScoreId { get; set; }

        [ForeignKey("ScoreId")]
        public Score Score { get; set; }

        public virtual ICollection<Application> Applications
        {
            get
            {
                return this.applications;
            }

            set
            {
                this.applications = value;
            }
        }

        public virtual ICollection<Document> Documents
        {
            get
            {
                return this.documents;
            }

            set
            {
                this.documents = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
