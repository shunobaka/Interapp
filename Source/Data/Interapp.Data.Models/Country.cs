namespace Interapp.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Country
    {
        private ICollection<User> users;
        private ICollection<University> universities;

        public Country()
        {
            this.users = new HashSet<User>();
            this.universities = new HashSet<University>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ModelConstants.CountryNameMinLength)]
        [MaxLength(ModelConstants.CountryNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }

        public virtual ICollection<University> Universities
        {
            get
            {
                return this.universities;
            }

            set
            {
                this.universities = value;
            }
        }
    }
}
