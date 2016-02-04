namespace Interapp.Data.Models
{
    using Common.Constants;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        private ICollection<User> users;

        public Country()
        {
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
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
    }
}
